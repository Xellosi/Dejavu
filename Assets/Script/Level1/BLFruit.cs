﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BLFruit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void click(){
		DialogueManager.Instance.StartDialogue("Level1/腐女的誕生",()=>SceneManager.LoadScene(0));
	}
}
