using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UI_manager : MonoBehaviour
{


    public GameObject UI_Jeu;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Ouvrir le Menu pause avec getkey
    }

    public void OnClickplay()
    {
        SceneManager.LoadScene("Play_Game");
    }
    public void OnClickExit()
    {
        Application.Quit();
    }
    public void OnClickUnPaused()
    {
        Debug.Log("You have clicked the button!");
        controller.UnPause();
        GameManager.s_Singleton.PauseTime(false);
        Cursor.visible = false;
        this.gameObject.SetActive(false);
        UI_Jeu.SetActive(true);
        Debug.Log(GameManager.s_Singleton.ReturnTime());
    }


}



