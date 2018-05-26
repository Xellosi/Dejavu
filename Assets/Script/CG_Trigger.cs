using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CG_Trigger : MonoBehaviour {

    string dialoguename = "two";


    public void TriggerDialogue()
    {

        FindObjectOfType<DialogueManager>().StartDialogue(dialoguename);
    }
}
