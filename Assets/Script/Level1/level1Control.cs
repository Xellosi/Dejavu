//https://stackoverflow.com/questions/24848332/how-do-i-make-a-dictionary-of-events
//http://allenchou.net/2018/07/readable-debuggable-multi-condition-game-code/
//https://stackoverflow.com/questions/540066/calling-a-function-from-a-string-in-c-sharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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
            CollideEvent[e.Objects] = e.FunctionName;
        }
    }

    void Start()
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
        temp["Potion"] = "未出現";
        temp["Tip"] = "關閉";
        temp["Leg"] = "未出現";
        temp["PotThings"] = "";
        temp["Fruit"] = "場景";
        temp["SeaShellMan"] = "未點擊";
        temp["Dolphin"] = "場景";
        return temp;
    }

    public override void LevelStart()
    {
        FadeController.Instance.FadeIn(1.0f, () => DialogueManager.Instance.StartDialogue("Level1/前言", () =>
        {
            SceneManager.LoadScene(2);
            FadeController.Instance.FadeIn(1.0f, () => DialogueManager.Instance.StartDialogue("Level1/進入房間", () =>
            {
                SceneManager.LoadScene(3);
                FadeController.Instance.FadeIn(1.0f, () =>
                {
                    DialogueManager.Instance.StartDialogue("Level1/走進調藥房");
                });
            }));
        }));
    }
    public void AllCollect()
    {
        if (PlayerDataManager.instance.data.Level1_Progress["Seaweed"] != "背包")
            return;
        if (PlayerDataManager.instance.data.Level1_Progress["Spoon"] != "背包")
            return;
        if (PlayerDataManager.instance.data.Level1_Progress["Leg"] != "背包")
            return;
        DialogueManager.Instance.StartDialogue("Level1/購得蛙腿", () => GetItemInfo.ShowGetInfo("Leg", () =>
        {
            Debug.Log("將蛙腿放入背包");
        }));
    }


    public override void CallCollideEvent(string name, GameObject hold, GameObject ground)
    {

        var m = ThisType.GetMethod(name);
        m.Invoke(this, new[] { hold, ground });
    }

    public void GloveAndEel(GameObject hold, GameObject ground)
    {
        DialogueManager.Instance.StartDialogue("Level1/拿電鰻_1", () =>
        {
            Destroy(hold);
            PlayerDataManager.instance.data.Level1_Progress["Glove"] = "消失";
            ground.GetComponent<Eel>().collected = true;
            ground.GetComponent<Eel>().PutInBag();
            PlayerDataManager.instance.data.Level1_Progress["Eel"] = "背包";
            GetItemInfo.ShowGetInfo("Eel", () =>
            {
                DialogueManager.Instance.StartDialogue("Level1/拿電鰻_2", () =>
                 {
                     var spoon = GameObject.Find("Spoon").GetComponent<Spoon>();
                     spoon.collected = true;
                     spoon.PutInBag();
                     PlayerDataManager.instance.data.Level1_Progress["Spoon"] = "背包";
                     GetItemInfo.ShowGetInfo("Spoon");
                 });
            });
        });
        hold.GetComponent<Glove>().PutInBag();
    }

    public void AddItemToPot(GameObject hold, GameObject ground)
    {
        if (PlayerDataManager.instance.data.Level1_Progress["PotThings"] == "")
        {
            if (hold.name != "Leg")
            {
                hold.GetComponent<ItemMoveBase>().PutInBag();
            }
            else
            {
                GameObject.Find("Soup").GetComponent<Image>().sprite = Resources.Load<Sprite>("Item/Level1/湯_蛙腳");
                PlayerDataManager.instance.data.Level1_Progress["PotThings"] = "Leg";
                PlayerDataManager.instance.data.Level1_Progress["Leg"] = "消失";
                Destroy(hold);
            }
        }
        else if (PlayerDataManager.instance.data.Level1_Progress["PotThings"] == "Leg")
        {
            if (hold.name != "Spoon")
            {
                hold.GetComponent<ItemMoveBase>().PutInBag();
            }
            else
            {
                GameObject.Find("Soup").GetComponent<Image>().sprite = Resources.Load<Sprite>("Item/Level1/湯_蛙腳_湯匙");
                PlayerDataManager.instance.data.Level1_Progress["PotThings"] = "Leg,Spoon";
                PlayerDataManager.instance.data.Level1_Progress["Spoon"] = "消失";
                Destroy(hold);
            }
        }
        else if (PlayerDataManager.instance.data.Level1_Progress["PotThings"] == "Leg,Spoon")
        {
            if (hold.name != "Seaweed")
            {
                hold.GetComponent<ItemMoveBase>().PutInBag();
            }
            else
            {
                GameObject.Find("Soup").GetComponent<Image>().sprite = Resources.Load<Sprite>("Item/Level1/湯_蛙腳_湯匙_海草");
                PlayerDataManager.instance.data.Level1_Progress["PotThings"] = "Leg,Spoon,Seaweed";
                PlayerDataManager.instance.data.Level1_Progress["Leg"] = "消失";
                Destroy(hold);
                GameObject potion = Instantiate(Resources.Load("Item/Level1/Potion", typeof(GameObject)) as GameObject);
                potion.transform.SetParent(GameObject.Find("BackGround").transform);
                potion.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                potion.name = "Potion";
                potion.GetComponent<Potion>().PutInBag();
                DialogueManager.Instance.StartDialogue("Level1/藥水完成", () => GetItemInfo.ShowGetInfo("Potion"));
                PlayerDataManager.instance.data.Level1_Progress["Potion"] = "背包";
                Debug.Log("GetPotion");
            }
        }
    }

    public void EelAndLaptop(GameObject hold, GameObject ground)
    {
        GameObject.Find("Charger").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        GameObject leg = Instantiate(Resources.Load("Item/Level1/Leg", typeof(GameObject)) as GameObject);
        leg.transform.SetParent(GameObject.Find("BackGround").transform);
        leg.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        leg.name = "Leg";
        leg.GetComponent<Leg>().PutInBag();
        DialogueManager.Instance.StartDialogue("Level1/電鰻放筆電", () => GetItemInfo.ShowGetInfo("Leg", () => CheckItemCollection()));
        PlayerDataManager.instance.data.Level1_Progress["Eel"] = "消失";
        Destroy(hold);
        //Resource Load Leg To Bag
        CheckItemCollection();
    }

    public void CheckItemCollection()
    {
        //https://answers.unity.com/questions/205391/how-to-get-list-of-child-game-objects.html
        //check child in inventory panel
        int targets = 0;
        foreach (Transform c in GameObject.Find("PanelGet").transform)
        {
            if (c.gameObject.name == "Seaweed")
                targets += 1;
            else if (c.gameObject.name == "Spoon")
                targets += 1;
            else if (c.gameObject.name == "Leg")
                targets += 1;
        }
        if (targets != 3)
            return;
        PlayerDataManager.instance.data.Level1_Progress["Tip"] = "開啟";
        DialogueManager.Instance.StartDialogue("Level1/東西到齊");
    }

    public void GlassAndDolphin(GameObject hold, GameObject ground)
    {
        Destroy(hold);
        DialogueManager.Instance.StartDialogue("Level1/拯救海豚", () =>
        {
            GameObject book = Instantiate(Resources.Load("Item/Level1/Book", typeof(GameObject)) as GameObject);
            book.transform.SetParent(GameObject.Find("BackGround").transform);
            book.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            book.name = "Book";
            book.GetComponent<Book>().PutInBag();
            GetItemInfo.ShowGetInfo("Book", () =>
            {
                DialogueManager.Instance.StartDialogue("Level1/獲得BL本");
                PlayerDataManager.instance.data.Level1_Progress["Glass"] = "消失";
                PlayerDataManager.instance.data.Level1_Progress["Dolphin"] = "消失";
                Destroy(ground);
            });
        });
    }
    public void BookAndSeaShellMan(GameObject hold, GameObject ground)
    {
        Destroy(hold);
        DialogueManager.Instance.StartDialogue("Level1/給貝殼人BL本", () =>
        {
            ground.GetComponent<Image>().sprite = Resources.Load<Sprite>("Item/Level1/貝殼人-色");
            GetItemInfo.ShowGetInfo("Fruit", () =>
            {
                PlayerDataManager.instance.data.Level1_Progress["Book"] = "消失";
                DialogueManager.Instance.StartDialogue("Level1/拿取果實");
                GameObject.Find("Level1End").transform.GetChild(0).gameObject.SetActive(true);
            });
        });
    }
}
