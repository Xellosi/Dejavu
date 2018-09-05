using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glove : ItemMoveBase
{

    // Use this for initialization
    void Start()
    {
        Init();
        if (PlayerDataManager.instance.data.Level1_Progress["Glove"] == "消失" || PlayerDataManager.instance.data.Level1_Progress["Glove"] == "包包")
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
        DialogueManager.Instance.StartDialogue("拿手套1", () => GetItemInfo.ShowGetInfo("Glove", () =>DialogueManager.Instance.StartDialogue("拿手套2",()=>this.collected = true)));
        PlayerDataManager.instance.data.Level1_Progress["Glove"] = "包包";
    }
}