using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Laptop : MonoBehaviour {

	// Use this for initialization
	public Image eel;
	void Start () {
		if(PlayerDataManager.instance.data.Level1_Progress["Eel"]=="消失"){
			eel.color = new Color(255,255,255,255);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Click(){
		if(PlayerDataManager.instance.data.Level1_Progress["Laptop"]=="未充電"){
			DialogueManager.Instance.StartDialogue("Level1/筆電_未充電");
		}
		else if (PlayerDataManager.instance.data.Level1_Progress["Laptop"]=="已充電"){
			DialogueManager.Instance.StartDialogue("Level1/筆電_已充電");
		}
	}
}
