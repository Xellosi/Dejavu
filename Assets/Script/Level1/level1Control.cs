// https://stackoverflow.com/questions/24848332/how-do-i-make-a-dictionary-of-events
//http://allenchou.net/2018/07/readable-debuggable-multi-condition-game-code/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
public class level1Control : MonoBehaviour {
	//Dictionary of the two objects which collided
	public Dictionary< string,Action<GameObject,GameObject>> DramaActions = new Dictionary<string,Action<GameObject,GameObject>>();
	//The look up Dictionary which map 
	public Dictionary< string,Action<GameObject,GameObject>> EventTable = new Dictionary<string, Action<GameObject, GameObject>>();
	string eventlogpath ="Level1/Level1Events";
	// dictionary string (hold.name+collide.name) , Action
	// Use this for initialization
	void Awake(){
		
		DramaTriggers drama = Resources.Load<DramaTriggers>(eventlogpath);
		foreach (var trigger in drama.triggers){
			foreach(string EventName in trigger.events){
				//如果有
				if (EventName.Contains ("Dialogue")) {
					DramaActions [trigger.name] += (GameObject arg1, GameObject arg2) => {
						DialogueManager.Instance.StartDialogue (EventName.Replace("Dialogue:",""));};
				} 
				else {
					if (!EventTable.ContainsKey (EventName)) {
						Debug.Log (EventName + "Not Done");
					} else if (EventName == "") {
						Debug.Log ("EmptyEvent!! in"+trigger.name);
					}else {
						DramaActions [trigger.name] += EventTable [EventName];
					}
				}
			}
		}
	}

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//初始化關卡 (預設物品 各物品劇情狀態)
	void Init(){
	}
	//參考當前狀態 (存檔的狀態 判斷是否觸發事件 改寫紀錄...etc) 
	public string eventcheck(GameObject a, GameObject b){
		return "";
	}


	//ToDo 創將整個Level各狀態值預設
	public SerializableDictionary<string,string> Level1Init(){
		return new SerializableDictionary<string,string> ();
	}
}
