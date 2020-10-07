using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{

    public List<Virus> waveVirus;
    int countDown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Wave(List<int> iVirus, List<Virus> poolVirus, int cd)
    {
        foreach (int v in iVirus)
        {
            if (poolVirus[v])
            {
                waveVirus.Add(poolVirus[v]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
