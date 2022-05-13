using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolfHit : MonoBehaviour
{
    TaskManager dm;
    DialogueTrigger startDialogue;
    public GameObject last;
    TaskTrigger startTask;
    public AudioSource aS;
    private int i = 0;

    void Start()
    {
        dm = FindObjectOfType<TaskManager>();
        startDialogue = GetComponent<DialogueTrigger>();
        startTask = GetComponent<TaskTrigger>();
    }

    void Clicked(){
        if(i == 0){
            dm.EndTask();
            startDialogue.TriggerDialogue();
            startTask.TriggerTask();
            i += 1;
        } 
        else if (i <= 8){
            i+=1;
        }
        else{
            gameObject.transform.Rotate(0f,0f,90f, Space.Self);
            gameObject.transform.position = new Vector3(0f,0f,0.4f)+gameObject.transform.position;
            last.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
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
