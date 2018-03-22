using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Tasks_Hit : MonoBehaviour {
    public GameObject TriggerPorteFin;
    public Text ZoneDeTexte;
    public GameObject GetOut;
    public GameObject Hits;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (TriggerPorteFin.GetComponent<DoorManager>().ReturnIndent() == 0)
        {
            ZoneDeTexte.text = "Status : Closed";

        }
        else if (TriggerPorteFin.GetComponent<DoorManager>().ReturnIndent() == 1)
        {
            ZoneDeTexte.text = "Status : Holding";
        }
        else if (TriggerPorteFin.GetComponent<DoorManager>().ReturnIndent() == 2)
        {
            ZoneDeTexte.text = "Status : Failing";
        }
        else if (TriggerPorteFin.GetComponent<DoorManager>().ReturnIndent() == 3)
        {
            GetOut.SetActive(true);
            Hits.SetActive(false);
            this.gameObject.SetActive(false);
        }
        else
        {
            ZoneDeTexte.text = "Status : Unknown";
        }
    }
}
