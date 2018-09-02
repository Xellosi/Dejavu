using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Laptop : MonoBehaviour {

	// Use this for initialization
	public Image eel;
	void Start () {
		if(PlayerDataManager.instance.Level1_Progress["Eel"]=="消失"){
			eel.gameObject.SetActive(true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Click(){
		if(PlayerDataManager.instance.Level1_Progress["Computer"]=="未充電"){
			DialogueManager.Instance.StartDialogue("筆電_未充電");
		}
		else if (PlayerDataManager.instance.Level1_Progress["Computer"]=="已充電"){

		}
	}
}
