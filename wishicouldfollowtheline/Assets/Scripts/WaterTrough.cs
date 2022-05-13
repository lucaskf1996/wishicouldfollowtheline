using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTrough : MonoBehaviour
{
    // public Material material2;
    public GameObject promptCanvas;
    public GameObject bucketHand;
    public GameObject bucketFloor;
    public GameObject waterBucket;
    public GameObject waterTrough;

    GameManager gm;
    TaskManager dm;
    DialogueTrigger startDialogue;
    TaskTrigger startTask;
    public AudioSource aS;

    void Start()
    {
        gm = GameManager.GetInstance();
        dm = FindObjectOfType<TaskManager>();
        startDialogue = GetComponent<DialogueTrigger>();
        startTask = GetComponent<TaskTrigger>();
    }

    void Clicked() {
        if(bucketHand.activeSelf && gm.waterCollected) {
            waterBucket.SetActive(false);
            waterTrough.SetActive(true);
            promptCanvas.SetActive(false);
            gm.waterPlaced = true;
            gameObject.tag = "Untagged";
            aS.Play(0);
            // gameObject.GetComponent<Renderer>().material = material2;
            dm.EndTask();
            startDialogue.TriggerDialogue();
            startTask.TriggerTask();
            bucketHand.SetActive(false);
            bucketFloor.GetComponent<Renderer>().enabled = true;
            gm.inHand = false;
        }
    }


    void HitByRay () {
        promptCanvas.SetActive(true);
    }

    void NotHitByRay () {
        promptCanvas.SetActive(false);
    }
}
