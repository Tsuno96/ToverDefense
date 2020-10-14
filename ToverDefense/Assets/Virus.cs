using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour
{
    public GameObject GO_Chemin;
    int currentCase;
    public float Speed;
    public float PV;
    Vector3 target;
    public int loot;
    public int damage;
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
        checkPV();
        
    }

    void OnTriggerEnter()
    {
        Destroy(gameObject);
        MGR_Player.Instance.hp -= damage;
        MGR_Player.Instance.checkBasePV();
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

    void checkPV()
    {
        if(PV<=0)
        {
            MGR_Player.Instance.gold += loot;
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage()
    {
        PV--;
        StartCoroutine("disableMesh");


    }

    IEnumerator disableMesh()
    {

        foreach(Transform child in transform)
        {
            MeshRenderer childMR = child.GetComponent<MeshRenderer>();
            if (childMR != null)
            {
                childMR.enabled = false;
            }
        }
        yield return new WaitForSeconds(0.25f);
        foreach (Transform child in transform)
        {
            MeshRenderer childMR = child.GetComponent<MeshRenderer>();
            if (childMR != null)
            {
                childMR.enabled = true;
            }
        }

    }
    

}
