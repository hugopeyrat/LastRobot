using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ReverseDetect : MonoBehaviour {
    private bool isTriggered = false;
    private bool buttonCheck = false;
    public bool StartDoor_isOpen = false;
    private bool Is_Active = false;
    private Vector3 actualPlace;
    private Quaternion actualRot;
    public GameObject ObjetDetruit;
    public GameObject MainObj;
    
    public GameObject PorteDebut;
    public GameObject TriggerPorteFin;
    private int ObjectCount;
    

    // Use this for initialization
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E) && isTriggered == true && this.tag == "Collectible")
        {

            Debug.Log("interact ok");
            ObjectCount++;
            MainObj.GetComponent<Animator>().Play("Robot_Anim_Interact1");
            if(ObjectCount == 1)
            {
                Destroy(PorteDebut);
            }
            GameManager.s_Singleton.IncrementeObjet();
            SetInteract(false);
        }

        if ((Input.GetKeyDown(KeyCode.E) && (isTriggered == true)) && ((this.tag == "SecBout") && (buttonCheck = false)))
        {
            GameManager.s_Singleton.OpenDoor();
            

            ObjetDetruit.gameObject.SetActive(true);
            buttonCheck = true;
            Debug.Log("Appuyé");
            Debug.Log(GameManager.s_Singleton.ReturnDoor());
            SetInteract(false);

            this.gameObject.SetActive(false);


        }

        else if ((Input.GetKeyDown(KeyCode.E) && (isTriggered == true)) && ((this.tag == "SecBout") && (buttonCheck = true)))
        {

            GameManager.s_Singleton.CloseDoor();

            ObjetDetruit.gameObject.SetActive(true);
            buttonCheck = false;
            TriggerPorteFin.GetComponent<DoorManager>().SwitchPorte("Closed");
            SetInteract(false);
            Debug.Log("Appuyé");
            this.gameObject.SetActive(false);

        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            MainObj.GetComponent<Animator>().Play("Robot_Animation1");
            if (isTriggered == true && this.tag == "Destructible")
            {
                /*actualPlace = this.transform.position;
                actualRot = this.transform.rotation;

                Instantiate(ObjetDetruit, actualPlace, actualRot);*/
                Destroy(this);
                SetHit(false);
            }
        }


      

 
    }

    void OnTriggerEnter(Collider collisionInfo)
    {



            if (collisionInfo.GetComponent<Collider>().tag == "Detecteur" && (this.tag == "Collectible" || this.tag == "SecBout"))
            {
                SetInteract(true);
            }

            if (collisionInfo.GetComponent<Collider>().tag == "Detecteur" && this.tag == "Destructible")
            {
            Debug.Log("Détecté");
            SetHit(true);
            }

        
        if (collisionInfo.GetComponent<Collider>().tag == "Detecteur" && this.tag == "Trigger")
        {
            Debug.Log("Triggered");
            Is_Active = true;
            MainObj.GetComponent<Animator>().Play("Anim_Regard_Haut");
            
            Destroy(this);

        }
    }

    void OnTriggerExit(Collider collisionInfo)
    {

        if (collisionInfo.GetComponent<Collider>().tag == "Detecteur" && this.tag == "Collectible")
        {
            SetInteract(false);
        }

        if (collisionInfo.GetComponent<Collider>().tag == "Detecteur" && this.tag == "Destructible")
        {
            SetHit(false);
        }
    }


    private void SetInteract(bool arg)
    {
        GameObject.Find("UI_IG/UI_Interact").GetComponent<Image>().enabled = arg;

        isTriggered = arg;
    }

    private void SetHit(bool arg)
    {
        GameObject.Find("UI_IG/UI_Hit").GetComponent<Image>().enabled = arg;
        isTriggered = arg;
    }

    public void Destruction()
    {
        Destroy(this.gameObject);
    }

    public void SetActiveDetect()
    {
        Is_Active = true;
    }
}
