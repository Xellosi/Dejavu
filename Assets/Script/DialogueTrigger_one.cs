using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueTrigger_one : MonoBehaviour {

   
    string dialoguename="one";

    
	public void TriggerDialogue ()
	{
		
		FindObjectOfType<DialogueManager>().StartDialogue(dialoguename);
	}

}
