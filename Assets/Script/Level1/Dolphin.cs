using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dolphin : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (PlayerDataManager.instance.data.Level1_Progress["Dolphin"] == "消失")
		Destroy(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void click(){
		if(PlayerDataManager.instance.data.Level1_Progress["Dolphin"]=="場景"){
			DialogueManager.Instance.StartDialogue("Level1/受困海豚");
		}
	}
}
