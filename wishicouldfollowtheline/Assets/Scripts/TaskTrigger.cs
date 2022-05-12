using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskTrigger : MonoBehaviour
{
    public string task;

    public void TriggerTask(){
        FindObjectOfType<TaskManager>().StartTask(task);
    }
}
