using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class level1Control : MonoBehaviour {
	Dictionary<Tuple<string ,string >,Action<GameObject ,GameObject >> a = new Dictionary<Tuple<string ,string >,Action<GameObject ,GameObject >>();
	// dictionary string (hold.name+collide.name) , Action
	// Use this for initialization
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
}
