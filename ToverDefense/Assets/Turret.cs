using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public float attackRate;
    public Belette belette;
    public float range;
    public Collider[] virusInRange;
    public Transform Base;
    public float reloadTime;
    public int cost;
    public Material mat;
    GameObject GOCercle;


    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponentInChildren<Renderer>().material ;
        reloadTime = 0;
        CreateCercle();
        
    }

    // Update is called once per frame
    void Update()
    {
        reloadTime += Time.deltaTime;
        virusInRange = Physics.OverlapSphere(transform.position, range, 1<<9);
        if (virusInRange.Length > 0)
        {
            float minDst = Mathf.Infinity;
            Transform target = transform;
            foreach (Collider c in virusInRange)
            {
                float dst = Vector3.Distance(c.gameObject.transform.position, Base.position);
                if (dst < minDst)
                {
                    minDst = dst;
                    target = c.gameObject.transform;
                }
            }
            transform.forward = Vector3.RotateTowards(transform.forward, transform.position - target.position, 5 * Time.deltaTime, 0.0f);
            if (reloadTime >= attackRate)
            {
                reloadTime = 0;
                SHOT(target);

            }
        }
        


    }


    void SHOT(Transform target)
    {
        Debug.Log("SHOT;");

        Belette b = belette;
        b.Initialise(target);
        Instantiate(b, transform.position, Quaternion.identity);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }


    void CreateCercle()
    {
        GOCercle = new GameObject();
    
        GOCercle.transform.parent = transform;
        GOCercle.transform.localPosition = Vector3.zero;
        GOCercle.transform.localRotation = new Quaternion(0, 180, 0,1);
        GOCercle.AddComponent<MeshFilter>();          // Creation d'un composant MeshFilter qui peut ensuite être visualisé
        GOCercle.AddComponent<MeshRenderer>();

        // Création des structures de données qui accueilleront sommets et  triangles  // Remplissage de la structure sommet 
        int[] triangles;
        Vector3[] vertices;
        int nmeridien = 50;
        vertices = new Vector3[nmeridien + 1];
        triangles = new int[nmeridien * 3];


        vertices[nmeridien] = new Vector3(0, 0, 0);

        for (int i = 0; i < nmeridien; i++)
        {
            vertices[i] = new Vector3(range * Mathf.Sin((2 * Mathf.PI * i + 1) / nmeridien), 0, range * Mathf.Cos((2 * Mathf.PI * i + 1) / nmeridien));

        }
        int k = 0;
        for (int j = 0; j < nmeridien; j++)
        {
            triangles[k] = nmeridien;
            triangles[k + 1] = (j);
            triangles[k + 2] = ((j) + 1) % nmeridien;
            k += 3;
        }


        // Remplissage de la structure triangle. Les sommets sont représentés par leurs indices
        // les triangles sont représentés par trois indices (et sont mis bout à bout)



        Mesh msh = new Mesh();                          // Création et remplissage du Mesh

        msh.vertices = vertices;
        msh.triangles = triangles;


        //foreach (Vector3 n in msh.vertices)
        //{
        //    Debug.Log(n);
        //}
        mat.mainTexture = null;
        mat.color = new Color(mat.color.r, mat.color.g, mat.color.b,0.15f);
        msh.RecalculateNormals();
        GOCercle.GetComponent<MeshFilter>().mesh = msh;           // Remplissage du Mesh et ajout du matériel
        GOCercle.GetComponent<MeshRenderer>().material = mat;
        

    }


}
