using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    

    public void MenuButton(){
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
    public void QuitButton(){
        Application.Quit();
    }
}
