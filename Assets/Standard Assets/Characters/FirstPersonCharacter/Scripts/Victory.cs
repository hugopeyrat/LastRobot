﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour {
    public GameObject Character;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider arg)
    {
        if(arg.tag == Character.GetComponent<Collider>().tag && (GameManager.s_Singleton.ReturnTimeFloat() > 0f))
        {
            SceneManager.LoadScene("Ecran_Win");
        }
    }
}
