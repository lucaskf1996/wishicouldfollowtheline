using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public GameObject pauseUI;
    public GameObject menu;
    public AudioMixer mixer;
    public Slider sMaster, sAmbient, sSFX, sDial;
    public GameObject Player;
    public GameObject Dialogue;
    public GameObject Continue, MainMenu, Quit;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(GameIsPaused){
                Resume();
                GameIsPaused = false;
                Player.SendMessage("unlockMouse");
                Dialogue.GetComponent<Canvas>().enabled = true;
            }
            else{
                Pause();
                GameIsPaused = true;
                Player.SendMessage("lockMouse");
                Dialogue.GetComponent<Canvas>().enabled = false;
            }
        }
    }

    void Resume(){
        menu.SetActive(false);
        Time.timeScale = 1f;
    }

    void Pause(){
        menu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void SetMasterVolume(){
        mixer.SetFloat("MasterVol", sMaster.value);
    }

    public void SetAmbientVolume(){
        mixer.SetFloat("AmbientVol", sAmbient.value);
    }

    public void SetSfxVolume(){
        mixer.SetFloat("SfxVol", sSFX.value);
    }

    public void SetDialVolume(){
        mixer.SetFloat("DialVol", sDial.value);
    }

    public void MainMenuButton(){
        Resume();
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void ContinueButton(){
        if(GameIsPaused){
            Resume();
            GameIsPaused = false;
            Player.SendMessage("unlockMouse");
            Dialogue.GetComponent<Canvas>().enabled = true;
        }
    }

    public void QuitButton(){
        Application.Quit();
    }
}
