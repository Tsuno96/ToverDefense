using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{

    public Turret turret;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (turret == null && MGR_Player.Instance.currentTurret != null)
        {
            if(MGR_Player.Instance.buyTurret())
            { 
            turret = MGR_Player.Instance.currentTurret;
            turret.Base = MGR_Player.Instance.Base;
            turret.transform.position = this.transform.position + new Vector3(0, 1, 0);
            Instantiate(turret);
            }
        }
    }
}
