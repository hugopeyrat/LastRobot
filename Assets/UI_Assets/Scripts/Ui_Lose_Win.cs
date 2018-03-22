using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Ui_Lose_Win : MonoBehaviour
{



    void Start()
    {
        Cursor.visible = true;
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
        SceneManager.LoadScene("Menu_Principal");
    }


}



