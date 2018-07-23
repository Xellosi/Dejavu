using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//http://allenchou.net/2018/07/readable-debuggable-multi-condition-game-code/
public class level1Control : MonoBehaviour {
	Dictionary<Tuple<string ,string >,Action<GameObject ,GameObject >> a = new Dictionary<Tuple<string ,string >,Action<GameObject ,GameObject >>();
	string path ="Level1/Level1Events";
	// dictionary string (hold.name+collide.name) , Action
	// Use this for initialization
	void Awake(){
		DramaTriggers drama = Resources.Load<DramaTriggers>(path);
		foreach (var triggers in drama.triggers){
			string[] e = triggers.name.Split(',');
			Debug.Log(e[0]+e[1]);
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
