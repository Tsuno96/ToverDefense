using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Belette : MonoBehaviour
{
    public Transform target;
    public float damage;
    public float speed = 5;
    public float impactRange;
    public float slowRate;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Initialise(Transform t)
    {
        target = t;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            transform.up = transform.position - target.position;
            if (transform.position == target.position)
            {
                Explode();
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Explode()
    {
        if(impactRange > 0)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, impactRange, 1 << 9);
            foreach (var hitCollider in hitColliders)
            {
                if(hitCollider.gameObject.GetComponent<Virus>() != null)
                { 
                hitCollider.gameObject.GetComponent<Virus>().TakeDamage();
                }
                Debug.Log(hitCollider.gameObject.GetComponent<Virus>());
            }
        }
        else
        {
            target.gameObject.GetComponent<Virus>().TakeDamage();
            target.gameObject.GetComponent<Virus>().Speed *= slowRate;
        }
        Destroy(this.gameObject);


    }

}
