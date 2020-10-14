using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;

public class Spawner : MonoBehaviour
{
    public GameObject GO_Chemin;
    public List<Virus> poolVirus;
    public List<Virus> waveVirus;
    float cdWave;
    public List<string> waves;
    public int currentWave;
    public int counter;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        ReadString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GO(float cd)
    {
        if(currentWave < waves.Count && counter <1)
        {
            List<int> iw = new List<int>();
            foreach (string str in waves[currentWave].Split())
            {
                int i;
                if(Int32.TryParse(str,out i))
                {
                    iw.Add(i);
                }
                else
                {
                    iw.Add(-1);
                }
            }
            SetWave(iw, cd);
            StartCoroutine("launchWave");
            currentWave++;
        }
    }



    public void SetWave(List<int> iWave, float cd)
    {
        waveVirus = new List<Virus>();
        cdWave = cd;
        foreach (int v in iWave)
        {
            if (v >= 0 && v < poolVirus.Count)
            {
                Virus virus = poolVirus[v];
                virus.Initialise(GO_Chemin);
                waveVirus.Add(virus);
            }
            else
            {
                waveVirus.Add(null);
            }
        }
    }

    IEnumerator launchWave()
    {
        counter = waveVirus.Count;
        foreach (Virus v in waveVirus)
        {
            if(v != null)
            {
                Instantiate(v);
               
            }
            counter--;
            yield return new WaitForSeconds(cdWave);
        }
    }

    public void ReadString()
    {
        string path = "Assets/waves.txt";
        waves = new List<string>();
        //Read the text from directly from the test.txt file
        string line;
        StreamReader reader = new StreamReader(path);
        while ((line = reader.ReadLine()) != null)
        {
            waves.Add(line);
        }
        reader.Close();
    }

}
