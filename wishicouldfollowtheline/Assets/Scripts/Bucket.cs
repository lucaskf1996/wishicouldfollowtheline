using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    public Material material1, material2;
    public GameObject promptCanvas;
    public GameObject carrotHand;
    public GameObject[] carrots;
    private int carrotCounter = 0;

    GameManager gm;

    void Start()
    {
        gm = GameManager.GetInstance();
    }

    void Clicked() {
        if(carrotCounter<carrots.Length && carrotHand.activeSelf) {
            carrotHand.SetActive(false);
            carrots[carrotCounter].SetActive(true);
            carrotCounter += 1;
            if(carrotCounter == carrots.Length){
                promptCanvas.SetActive(false);
                gm.carrotsPlaced = true;
                gameObject.tag = "Untagged";
                gameObject.GetComponent<Renderer>().material = material2;
            }
            gm.inHand = false;
        }
    }


    void HitByRay () {
        if(carrotCounter<carrots.Length){
            promptCanvas.SetActive(true);
            gameObject.GetComponent<Renderer>().material = material1;
        }
    }

    void NotHitByRay () {
        promptCanvas.SetActive(false);
        gameObject.GetComponent<Renderer>().material = material2;
    }
}
