using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorManager : MonoBehaviour {
    private bool is_triggered;
    public GameObject PorteFermee;
    public GameObject PorteUnCoup;
    public GameObject PorteDeuxCoup;
    public GameObject PorteCassee;
    public GameObject Character;

    private int indent = 0;

    void Start () {

        
    }

    void Update()
    {
        if(GameManager.s_Singleton.ReturnDoor() == true)
        {
            SwitchPorte("Open");
        }
        else
        {
            if (indent == 0)
            {
                SwitchPorte("Closed");
            }

            if ((is_triggered == true) && (Input.GetKeyDown(KeyCode.F) && (GameManager.s_Singleton.ReturnObjet() >= 5)))
            {
                indent++;
                if (indent == 1 || indent == 2)
                {
                    Character.GetComponent<Animator>().enabled = true;
                    Character.GetComponent<Animator>().Play("Robot_Porte1");
                }
                else if (indent == 3)
                {
                    Character.GetComponent<Animator>().enabled = true;
                    Character.GetComponent<Animator>().Play("Robot_Porte1");

                }
                else
                {
                    indent = 0;
                }

            }




        }
    }


        void OnTriggerEnter(Collider collisionInfo)
        {
            if(collisionInfo.GetComponent<Collider>().tag == "Detecteur")
            {
                is_triggered = true;
            if (GameManager.s_Singleton.ReturnObjet() >= 5)
            {
                GameObject.Find("UI_IG/UI_Hit").GetComponent<Image>().enabled = true;
            }
                
                
            }

        }

        void OnTriggerExit(Collider collisionInfo)
        {
            if (collisionInfo.GetComponent<Collider>().tag == "Detecteur")
            {
                is_triggered = false;
            if (GameManager.s_Singleton.ReturnObjet() >= 5)
            {
                GameObject.Find("UI_IG/UI_Hit").GetComponent<Image>().enabled = false;
            }
        }

        }

    public void SwitchPorte(string arg)
    {
        switch(arg){
            case "Open":
                PorteFermee.SetActive(false);
                PorteDeuxCoup.SetActive(false);
                PorteCassee.SetActive(false);
                PorteUnCoup.SetActive(false);
                break;

            case "Closed":
                PorteFermee.SetActive(true);
                PorteDeuxCoup.SetActive(false);
                PorteCassee.SetActive(false);
                PorteUnCoup.SetActive(false);
                break;

            case "UnCoup":
                PorteFermee.SetActive(false);
                PorteDeuxCoup.SetActive(false);
                PorteCassee.SetActive(false);
                PorteUnCoup.SetActive(true);
                break;

            case "DeuxCoup":
                PorteFermee.SetActive(false);
                PorteDeuxCoup.SetActive(true);
                PorteCassee.SetActive(false);
                PorteUnCoup.SetActive(false);
                break;

            case "Cassee":
                PorteFermee.SetActive(false);
                PorteDeuxCoup.SetActive(false);
                PorteCassee.SetActive(true);
                PorteUnCoup.SetActive(false);
                break;
        }
    }

    public int ReturnIndent()
    {
        return indent;
    }

    public void SetIndent(int arg)
    {
        indent = arg;
    }

    public bool CheckIfTrigger()
    {
        return is_triggered;
    }



}
