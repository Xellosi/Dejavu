using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eel : ItemMoveBase {

	// Use this for initialization
	void Start () {
		DirectPick = false;
		Init ();
		if(PlayerDataManager.instance.Level1_Progress["Eel"]=="消失" || PlayerDataManager.instance.Level1_Progress["Eel"]=="包包"){
			Destroy(this.gameObject);
			return;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	bool CheckInBag(string name){
		foreach(Transform child in transform){
			if (name == child.gameObject.name){
				return true;
			}
		}
		return false;
	}

	public override void picking(){
		GetItemInfo.ShowGetInfo("Eel");
	}

}
