using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Tasks_Plugin : MonoBehaviour {
    public Text ZoneDeTexte;
    public GameObject Hit1;
    public GameObject Hit2;
    public GameObject Plugins;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.s_Singleton.ReturnObjet() < 5)
        {
            ZoneDeTexte.text = GameManager.s_Singleton.ReturnObjet().ToString() + " / 5";
        }
        else
        {
            Hit1.SetActive(true);
            Hit2.SetActive(true);
            Plugins.SetActive(false);
            this.gameObject.SetActive(false);
        }
        
    }

}
