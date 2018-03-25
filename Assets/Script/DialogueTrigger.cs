using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueTrigger : MonoBehaviour {

	string dialoguename;

	public void TriggerDialogue ()
	{
		dialoguename = GameObject.Find ("InputField").GetComponentInChildren<Text> ().text;
		FindObjectOfType<DialogueManager>().StartDialogue(dialoguename);
	}

}
