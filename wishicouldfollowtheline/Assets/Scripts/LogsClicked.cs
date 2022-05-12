using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogsClicked : MonoBehaviour
{
    public GameObject axe;
    GameManager gm;
    private int count = 0;
    public AudioClip[] audios;
    private AudioSource source;
    // TaskManager tm;
    // DialogueTrigger startDialogue;
    // TaskTrigger startTask;

    void Start(){
        gm = GameManager.GetInstance();
        source = GetComponent<AudioSource>();
        source.clip = audios[0];
        // tm = FindObjectOfType<TaskManager>();
        // startDialogue = GetComponent<DialogueTrigger>();
        // startTask = GetComponent<TaskTrigger>();
    }

    void Clicked(){
        if(axe.activeSelf && gm.waterPlaced){
            if(count < 2){
                source.Play();
                count++;
            }
            if(count == 2){
                source.clip = audios[1];
                source.Play();
                // tm.EndTask();
                // startDialogue.TriggerDialogue();
                // startTask.TriggerTask();
            }
        }
    }
}
