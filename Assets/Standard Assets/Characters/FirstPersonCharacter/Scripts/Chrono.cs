using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chrono : MonoBehaviour {
    public Text ZoneDeTexte;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ZoneDeTexte.text = GameManager.s_Singleton.ReturnTime();
	}
}
