using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    
    GameManager gm;

    void Start(){
        gm = GameManager.GetInstance();
    }
    public void MenuButton(){
        gm.Reset();
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
    public void QuitButton(){
        Application.Quit();
    }
}
