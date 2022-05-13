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

    public AudioSource aS;
    GameManager gm;
    TaskManager dm;
    DialogueTrigger startDialogue;
    TaskTrigger startTask;

    void Start()
    {
        gm = GameManager.GetInstance();
        dm = FindObjectOfType<TaskManager>();
        startDialogue = GetComponent<DialogueTrigger>();
        startTask = GetComponent<TaskTrigger>();
    }

    void Clicked() {
        if(carrotCounter<carrots.Length && carrotHand.activeSelf) {
            carrotHand.SetActive(false);
            carrots[carrotCounter].SetActive(true);
            aS.Play(0);
            carrotCounter += 1;
            if(carrotCounter == carrots.Length){
                promptCanvas.SetActive(false);
                gm.carrotsPlaced = true;
                gameObject.tag = "Untagged";
                gameObject.GetComponent<Renderer>().material = material2;
                dm.EndTask();
                startDialogue.TriggerDialogue();
                startTask.TriggerTask();
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
