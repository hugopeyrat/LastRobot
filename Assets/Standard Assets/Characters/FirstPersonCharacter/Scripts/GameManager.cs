using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private int objetsRamasses = 0;
    private bool DoorOpen = false;

    private float timer = 600.0f;
    private bool onPause = false;

    public static GameManager s_Singleton;

    void Awake()
    {
        if(s_Singleton != null)
        {
            Destroy(gameObject);
        }
        else
        {
            s_Singleton = this;
        }
    }



	void Update () {
        if (!onPause)
        {
            timer -= Time.deltaTime;
        }
		
        if(timer <= 0)
        {
            SceneManager.LoadScene("Ecran_Defaite");
        }
	}



    public void IncrementeObjet()
    {
        objetsRamasses++;
        Debug.Log(objetsRamasses);
    }

    public int ReturnObjet()
    {
        return objetsRamasses;
    }

    public void OpenDoor()
    {
        DoorOpen = true;
    }
    public void CloseDoor()
    {
        DoorOpen = false;
    }

    public bool ReturnDoor()
    {
        return true;
    }

    public string ReturnTime()
    {
        var temp = timer / 60;
        var temp2 = Mathf.Floor(temp);
        var temp3 = ((temp - temp2)/100)*60;
        var someString = string.Format("{0:0}:{1:00}", Mathf.Floor(timer / 60), timer % 60);
        //return temp2.ToString() + ".";
        return someString;
    }

    public float ReturnTimeFloat()
    {
        
        return timer;
    }

    public void PauseTime(bool arg)
    {
        onPause = arg;
    }

}
