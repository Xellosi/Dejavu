using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class level1Control : MonoBehaviour {
	Dictionary<Tuple<string ,string > ,string > a = new Dictionary<Tuple<string ,string >, string>();
	// dictionary string (hold.name+collide.name) , Action
	// Use this for initialization
	void Start () {
		Tuple<string,string> x = new Tuple<string, string> ("1", "2");
		Tuple<string,string> y = new Tuple<string, string> ("1", "2");
		a[x]="3";
		Debug.Log(a.ContainsKey(y));
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
