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
    TaskManager tm;
    public DialogueTrigger midDialogue;
    public DialogueTrigger startDialogue;
    TaskTrigger startTask;
    public GameObject horse;
    public GameObject deadHorse;

    void Start(){
        gm = GameManager.GetInstance();
        source = GetComponent<AudioSource>();
        source.clip = audios[0];
        tm = FindObjectOfType<TaskManager>();
        // startDialogue = GetComponent<DialogueTrigger>();
        startTask = GetComponent<TaskTrigger>();
    }

    void Clicked(){
        if(axe.activeSelf && gm.waterPlaced){
            if(count < 2){
                source.Play();
                midDialogue.TriggerDialogue();
                count++;
            }
            if(count == 2){
                horse.SetActive(false);
                deadHorse.SetActive(true);
                deadHorse.GetComponent<AudioSource>().Play();
                tm.EndTask();
                startDialogue.TriggerDialogue();
                startTask.TriggerTask();
                gameObject.tag = "Untagged";
            }
        }
    }
}
