using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horseClicked : MonoBehaviour
{
    TaskManager tm;
    DialogueTrigger startDialogue;
    TaskTrigger startTask;
    public GameObject[] casa;

    void Start(){
        tm = FindObjectOfType<TaskManager>();
        startDialogue = GetComponent<DialogueTrigger>();
        startTask = GetComponent<TaskTrigger>();
    }

    public GameObject wolf;
    void Clicked(){
        wolf.GetComponent<AudioSource>().Play();
        tm.EndTask();
        startDialogue.TriggerDialogue();
        startTask.TriggerTask();
        gameObject.tag = "Untagged";
        foreach(GameObject pedaco in casa){
            pedaco.GetComponent<Renderer>().enabled = false;
        }
    }

    void HitByRay () {
        while(true){
            break;
        }
    }

    void NotHitByRay () {
        while(true){
            break;
        }
    }
}
