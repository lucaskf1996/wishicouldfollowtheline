using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Well : MonoBehaviour
{
    public Material material2;
    public GameObject promptCanvas;
    public GameObject bucketHand;
    public GameObject water;

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
        if(bucketHand.activeSelf) {
            water.SetActive(true);
            promptCanvas.SetActive(false);
            gm.waterCollected = true;
            gameObject.tag = "Untagged";
            gameObject.GetComponent<Renderer>().material = material2;
            dm.EndTask();
            startDialogue.TriggerDialogue();
            startTask.TriggerTask();
        }
    }


    void HitByRay () {
        promptCanvas.SetActive(true);
    }

    void NotHitByRay () {
        promptCanvas.SetActive(false);
    }
}
