using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : ItemMoveBase {


	void Awake()
	{
        Init();
        if (PlayerDataManager.instance.data.Level1_Progress["Fruit"] == "消失" || PlayerDataManager.instance.data.Level1_Progress["Fruit"] == "背包")
        {
            Destroy(this.gameObject);
            return;
        }
	} 
	
	// Update is called once per frame
	void Update () {
		
	}
	public override void picking()
    {
        DialogueManager.Instance.StartDialogue("Level1/獲得果實", () => GetItemInfo.ShowGetInfo("Fruit",()=>this.collected = true));
        PlayerDataManager.instance.data.Level1_Progress["Fruit"] = "背包";
    }
}
