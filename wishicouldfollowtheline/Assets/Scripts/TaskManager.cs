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

    public IEnumerator StartTask(string task){
        yield return new WaitUntil(() => gm.inDialogue == false);
        Debug.Log("Starting task");
        taskText.gameObject.SetActive(true);

        taskText.text = task;
        Debug.Log(task);
    }

    public void EndTask(){
        taskText.text = " ";
        taskText.gameObject.SetActive(false);
    }
}
