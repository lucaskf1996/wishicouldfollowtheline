using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBucket : MonoBehaviour
{
    public GameObject handItem;
    public GameObject handle;
    public GameObject promptCanvas;
    // public Material material1, material2;
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


    void Clicked () {
        if(gm.carrotsPlaced){
            if (!gm.inHand && !handItem.activeSelf){
                handItem.SetActive(true);
                gameObject.tag = "Untagged";
                handle.GetComponent<Renderer>().enabled = false;
                gameObject.GetComponent<Renderer>().enabled = false;
                gm.inHand = true;
                dm.EndTask();
                startDialogue.TriggerDialogue();
                startTask.TriggerTask();
            }
        }
    }

    void HitByRay () {
        promptCanvas.SetActive(true);
        // gameObject.GetComponent<Renderer>().material = material1;
    }

    void NotHitByRay () {
        promptCanvas.SetActive(false);
        // gameObject.GetComponent<Renderer>().material = material2;
    }
}
