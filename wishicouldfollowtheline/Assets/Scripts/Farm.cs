using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : MonoBehaviour
{
    GameManager gm;

    void Start()
    {
        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.carrotsPlaced){
            foreach(Transform child in transform){
                foreach(Transform grandchild in child){
                    grandchild.tag = "Untagged";
                }
            }
        }
    }
}
