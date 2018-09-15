using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seaweed : ItemMoveBase
{

    // Use this for initialization
    void Start()
    {
        Init();
        if (PlayerDataManager.instance.data.Level1_Progress["Seaweed"] == "消失" || PlayerDataManager.instance.data.Level1_Progress["Seaweed"] == "背包")
        {
            Destroy(this.gameObject);
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


	//需在點完獲得物品消息在設collected為true 防止點物品後可直接拖拉
    public override void picking()
    {
        DialogueManager.Instance.StartDialogue("Level1/拿海藻", () =>GetItemInfo.ShowGetInfo("Seaweed", ()=>{this.collected = true;
        GameManager.Instance.GetComponent<Level1Control>().CheckItemCollection();}));
        PlayerDataManager.instance.data.Level1_Progress["Seaweed"] = "背包";
    }
}
