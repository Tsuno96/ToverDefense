using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MGR_Text : MonoBehaviour
{

    private static MGR_Text p_instance = null;
    public static MGR_Text Instance { get { return p_instance; } }

    public GameObject goldText;
    public GameObject pvText;
    public List<GameObject> textButtons;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < MGR_Player.Instance.poolTurrets.Count;i++)
        {
            textButtons[i].GetComponent<Text>().text += " Prix : " + MGR_Player.Instance.poolTurrets[i].cost;
        }
    }

    // Update is called once per frame
    void Update()
    {
        goldText.GetComponent<Text>().text = "Bitcoin : "+MGR_Player.Instance.gold;
        pvText.GetComponent<Text>().text = "PV : "+MGR_Player.Instance.hp;

    }
}
