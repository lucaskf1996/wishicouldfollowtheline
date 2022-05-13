using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    private Queue<string> names;
    public AudioClip[] audios;
    public AudioSource audioS;
    public Text nameText;
    public Text dialogueText;
    private int audio = 0;
    
    GameManager gm;

    void Start()
    {
        gm = GameManager.GetInstance();
        sentences = new Queue<string>();
        names = new Queue<string>();
        DialogueTrigger startDialogue = GetComponent<DialogueTrigger>();
        TaskTrigger startTask = GetComponent<TaskTrigger>();
        startDialogue.TriggerDialogue();
        startTask.TriggerTask();
    }

    public void StartDialogue(Dialogue dialogue){
        Debug.Log("Starting conversation");
        gm.allowMovement = false;
        gm.inDialogue = true;
        nameText.gameObject.SetActive(true);
        dialogueText.gameObject.SetActive(true);
        sentences.Clear();
        names.Clear();

        for(int i=0; i<dialogue.sentences.Length; i++){
            sentences.Enqueue(dialogue.sentences[i]);
            names.Enqueue(dialogue.name[i]);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence(){
        if(sentences.Count == 0){
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        string name = names.Dequeue();

        Debug.Log(audios.Length);
        Debug.Log(audio);
        audioS.clip = audios[audio];
        audioS.Play();
        audio += 1;
        nameText.text = name;
        dialogueText.text = sentence;
        Debug.Log(sentence);
    }

    void EndDialogue(){
        nameText.gameObject.SetActive(false);
        dialogueText.gameObject.SetActive(false);
        gm.allowMovement = true;
        Cursor.lockState = CursorLockMode.Locked;
        gm.inDialogue = false;
    }
}
