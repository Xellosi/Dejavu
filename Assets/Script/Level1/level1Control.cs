// https://stackoverflow.com/questions/24848332/how-do-i-make-a-dictionary-of-events
//http://allenchou.net/2018/07/readable-debuggable-multi-condition-game-code/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
public class Level1Control : ControlBase {
	string eventlogpath ="Level1/Level1Events";
	public enum level1Item {}
	public enum level1State{}
	void Awake(){
		
		DramaTriggers drama = Resources.Load<DramaTriggers>(eventlogpath);
		foreach (var trigger in drama.triggers){
			foreach(string EventName in trigger.events){
				//如果有
				if (EventName.Contains ("對話")) {
					DramaActions [trigger.name] += (GameObject arg1, GameObject arg2) => {
						DialogueManager.Instance.StartDialogue (EventName.Replace("對話:",""));};
				} 
				else {
					if (!EventTable.ContainsKey (EventName)){
						Debug.Log (EventName + "Not Done");
					}else if (EventName == "") {
						Debug.Log ("EmptyEvent!! in"+trigger.name);
					}else{
						
					}
				}
			}
		}
	}

	void Start () {
	}
	
	//初始化關卡 (預設物品 各物品劇情狀態)
	public override void Init(){

	}
	//參考當前狀態 (存檔的狀態 判斷是否觸發事件 改寫紀錄...etc) 
	public string EventCheck(GameObject a, GameObject b){
		return "";
	}


	//ToDo 創將整個Level各狀態值預設
	public SerializableDictionary<string,string> Level1SaveInit(){
		var temp = new SerializableDictionary<string,string>();
		temp["Laptop"]="未充電";
		temp["Eel"]="場景";
		temp["Seaweed"]="場景";
		temp["Glove"]="場景";
		temp["Spoon"]="場景";
		temp["Glass"]="未出現";
		temp["Position"]="未出現";
		temp["Tip"]="關閉";
		temp["Leg"]="未出現";
		return temp;
	}

}
