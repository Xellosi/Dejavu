using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger_two : MonoBehaviour {

    string dialoguename = "two";


    public void TriggerDialogue()
    {

        FindObjectOfType<DialogueManager>().StartDialogue(dialoguename);
    }
}
