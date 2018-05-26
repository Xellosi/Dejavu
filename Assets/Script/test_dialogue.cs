using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_dialogue : MonoBehaviour {

	// Use this for initialization
	void Start () {
        FindObjectOfType<DialogueManager>().StartDialogue("two");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
