using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    public Text taskText;
    
    GameManager gm;

    void Start()
    {
        gm = GameManager.GetInstance();
    }

    public void StartTask(string task){
        Debug.Log("Starting task");
        taskText.gameObject.SetActive(true);

        taskText.text = task;
        Debug.Log(task);
    }

    void EndTask(){
        taskText.text = " ";
        taskText.gameObject.SetActive(false);
    }
}
