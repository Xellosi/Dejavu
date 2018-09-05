//https://stackoverflow.com/questions/24848332/how-do-i-make-a-dictionary-of-events
//http://allenchou.net/2018/07/readable-debuggable-multi-condition-game-code/
//https://stackoverflow.com/questions/540066/calling-a-function-from-a-string-in-c-sharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
public class Level1Control : ControlBase
{
    string eventlogpath = "Level1/Level1CollideEventList";
    Type ThisType;
    public enum level1State { }
    void Awake()
    {
        ThisType = this.GetType();
        CollideEventList Events = (CollideEventList)Instantiate(Resources.Load(eventlogpath, typeof(CollideEventList)));
        foreach (var e in Events.CollideName)
        {
            CollideDrama[e.Objects] = e.FunctionName;
            Debug.Log(e.Objects + "," + e.FunctionName);
        }
    }

    void Start()
    {

    }

    //初始化關卡 (預設物品 各物品劇情狀態)
    public override void Init()
    {

    }
    //參考當前狀態 (存檔的狀態 判斷是否觸發事件 改寫紀錄...etc) 
    public string EventCheck(GameObject a, GameObject b)
    {
        return "";
    }


    //ToDo 創將整個Level各狀態值預設
    public override SerializableDictionary<string, string> SaveInit()
    {
        var temp = new SerializableDictionary<string, string>();
        temp["Laptop"] = "未充電";
        temp["Eel"] = "場景";
        temp["Seaweed"] = "場景";
        temp["Glove"] = "場景";
        temp["Spoon"] = "場景";
        temp["Glass"] = "未出現";
        temp["Position"] = "未出現";
        temp["Tip"] = "關閉";
        temp["Leg"] = "未出現";
        return temp;
    }

    public void AllCollect()
    {
        if (PlayerDataManager.instance.data.Level1_Progress["Seaweed"] != "包包")
            return;
        if (PlayerDataManager.instance.data.Level1_Progress["Glove"] != "包包")
            return;
        if (PlayerDataManager.instance.data.Level1_Progress["Spoon"] != "包包")
            return;
        if (PlayerDataManager.instance.data.Level1_Progress["Leg"] != "包包")
            return;
        DialogueManager.Instance.StartDialogue("購得蛙腿", () => GetItemInfo.ShowGetInfo("Leg", () =>
        {
            Debug.Log("將蛙腿放入包包");
        }));
    }


    public override void CallCollideEvent(string name, GameObject hold, GameObject ground)
    {
        Debug.Log(name+","+hold.name+","+ground.name);
        var m = ThisType.GetMethod(name);
        m.Invoke(this,new[]{hold,ground});
    }

    public void GloveAndEel(GameObject hold, GameObject ground){
        DialogueManager.Instance.StartDialogue("拿手套1");
    }
}
