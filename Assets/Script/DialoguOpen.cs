using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueOpen : MonoBehaviour {

    

    

    
	public void StartDialogue ()
	{
        string dialoguename = "one";
        FindObjectOfType<DialogueManager>().StartDialogue(dialoguename);
	}

}
