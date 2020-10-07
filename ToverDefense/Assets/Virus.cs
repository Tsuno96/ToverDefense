using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour
{

    public GameObject GO_Chemin;
    int currentCase;
    public int Speed;
    Vector3 target;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Initialise(GameObject chemin)
    {
        GO_Chemin = chemin;
        currentCase = 0;
        SetTarget(currentCase);
        this.transform.position = new Vector3(target.x, target.y, target.z);
    }

    // Update is called once per frame
    void Update()
    {
        followPath();
    }

    void followPath()
    {
        SetTarget(currentCase);
        if (transform.position != target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, Speed * Time.deltaTime);
        }
        else
        {
            currentCase++;
        }

    }
    void SetTarget(int t)
    {
        if (t < GO_Chemin.transform.childCount)
        {
            target = GO_Chemin.transform.GetChild(t).position;
            target += new Vector3(0,1,0);
        }
    }

}
