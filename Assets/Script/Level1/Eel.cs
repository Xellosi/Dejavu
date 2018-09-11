using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Eel : ItemMoveBase {

	// Use this for initialization
	void Start () {
		DirectPick = false;
		Init ();
		if(PlayerDataManager.instance.data.Level1_Progress["Eel"]=="消失" || PlayerDataManager.instance.data.Level1_Progress["Eel"]=="包包"){
			Destroy(this.gameObject);
			return;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public override void picking(){
		GetItemInfo.ShowGetInfo("Eel");
	}
	public override void ProtectedPick(){
		DialogueManager.Instance.StartDialogue("Level1/徒手拿電鰻");
	}

}
