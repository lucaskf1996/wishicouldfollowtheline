using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject handItem;
    GameManager gm;

    void Start()
    {
        gm = GameManager.GetInstance();
    }


    void Clicked () {
        if (!gm.inHand && !handItem.activeSelf){
            handItem.SetActive(true);
            gameObject.tag = "Untagged";
            if(transform.childCount > 0){
                gameObject.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
            }
            gameObject.GetComponent<Renderer>().enabled = false;
            gm.inHand = true;
        }
    }
}
