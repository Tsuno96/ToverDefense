using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject GO_Chemin;
    public List<Virus> poolVirus;
    List<Virus> waveVirus;
    List<int> iVirusWave;
    float cdWave;

    // Start is called before the first frame update
    void Start()
    {
        waveVirus = new List<Virus>();
        SetWave(new List<int>() { 0, 1, poolVirus.Count, 2 }, 2);
        StartCoroutine("launchWave");
        /*Virus virus = poolVirus[0];
        virus.Initialise(GO_Chemin);
        Instantiate(virus);*/
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetWave(List<int> w, float cd)
    {
        iVirusWave = w;
        cdWave = cd;
    }



    IEnumerator launchWave()
    {
        foreach(int v in iVirusWave)
        {
            if (v >=0 && v<poolVirus.Count)
            {
                Virus virus = poolVirus[v];
                virus.Initialise(GO_Chemin);
                waveVirus.Add(virus);
                Instantiate(virus);
                
            }
            yield return new WaitForSeconds(cdWave);
        }


    }

    

}
