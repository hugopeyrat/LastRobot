using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UI_manager2 : MonoBehaviour
{

    public Button resume;
    public Button restart;
    public Button quit;
    public GameObject UI_Jeu;
    public Slider Son;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;

    public AudioSource volumeAudio;

    void Start()
    {

        
        restart.onClick.AddListener(RestartGame);
        quit.onClick.AddListener(QuitGame);
    }

    void Resume()
    {
        Debug.Log("You have clicked the button!");
        controller.UnPause();
        GameManager.s_Singleton.PauseTime(false);
        Cursor.visible = false;
        this.gameObject.SetActive(false);
        UI_Jeu.SetActive(true);
        Debug.Log(GameManager.s_Singleton.ReturnTime());
    }

    void RestartGame()
    {
        SceneManager.LoadScene("Play_Game");
    }

    void QuitGame()
    {
        SceneManager.LoadScene("Menu_Principal");
    }
    public void VolumeController()
    {
        volumeAudio.volume = Son.value;
    }

}



