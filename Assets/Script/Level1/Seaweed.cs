using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seaweed : ItemMoveBase
{

    // Use this for initialization
    void Start()
    {
        Init();
        if (PlayerDataManager.instance.Level1_Progress["Seaweed"] == "消失" || PlayerDataManager.instance.Level1_Progress["Seaweed"] == "包包")
        {
            Destroy(this.gameObject);
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void picking()
    {
        DialogueManager.Instance.StartDialogue("拿海藻", () =>GetItemInfo.ShowGetInfo("Seaweed", ()=>this.collected = true));
        PlayerDataManager.instance.Level1_Progress["Seaweed"] = "包包";
    }
}
