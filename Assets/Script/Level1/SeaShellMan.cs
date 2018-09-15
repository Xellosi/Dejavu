using System.Collections;
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
		if (PlayerDataManager.instance.data.Level1_Progress["Fruit"]=="背包"){
			DialogueManager.Instance.StartDialogue("Level1/未拿取愛情故事");
		}
		//未拿取
		else{

		}
	}
}
