using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MGR_Player : MonoBehaviour
{

    public Transform Base;
    public int gold;
    public int hp;
    public List<Turret> poolTurrets;
    public Turret currentTurret;
    private static MGR_Player p_instance = null;
    public static MGR_Player Instance { get { return p_instance; } }
    void Awake()
    {
        if (p_instance == null)
            //if not, set instance to this
            p_instance = this;
        //If instance already exists and it's not this:
        else if (p_instance != this)
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
    }
        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void chooseCurrentTurret(int iTurret)
    {
        switch(iTurret)
        {
            case 0: currentTurret = poolTurrets[0];
                break;            
            case 1: currentTurret = poolTurrets[1];
                break;            
            case 2: currentTurret = poolTurrets[2];
                break;
            default: currentTurret = poolTurrets[0];
                break;
        }
    }

    public bool buyTurret()
    {
        if(gold >= currentTurret.cost)
        {
            gold -= currentTurret.cost;
            return true;
        }

        return false;
    }

    public void checkBasePV()
    {
        if(hp<=0)
        {
            Debug.Log("Perdu");
            SceneManager.LoadScene("LoseScene");
        }
    }


}
