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

        SetWave(new List<int>() { 0, 0, 0, 0 }, 2);
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
            if (true)
            {
                Virus virus = poolVirus[v];
                virus.Initialise(GO_Chemin);
                waveVirus.Add(virus);
                //Instantiate(waveVirus[waveVirus.Count -1]);
                yield return new WaitForSeconds(cdWave);
            }
        }


    }

    

}
