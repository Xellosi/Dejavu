﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SeaShellMan : MonoBehaviour {

	// Use this for initialization
	public Button shellman;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Click(){
		//已拿取胸部果實
		if (PlayerDataManager.instance.data.Level1_Progress["SeaShellMan"]=="未點擊"){
			DialogueManager.Instance.StartDialogue("Level1/初次點擊貝殼人");
			PlayerDataManager.instance.data.Level1_Progress["SeaShellMan"]="已點擊";
		}
		//未拿取
		else if (PlayerDataManager.instance.data.Level1_Progress["SeaShellMan"]=="已點擊"){
			DialogueManager.Instance.StartDialogue("Level1/已點擊貝殼人");
		}
	}
}
