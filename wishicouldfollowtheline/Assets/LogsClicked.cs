using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogsClicked : MonoBehaviour
{
    public GameObject axe;
    GameManager gm;
    private int count = 0;

    void Start(){
        gm = GameManager.GetInstance();
    }

    void Clicked(){
        if(axe.activeSelf && gm.waterPlaced){
            if(count < 2){
                GetComponent<AudioSource>().Play();
            }
        }
    }
}
