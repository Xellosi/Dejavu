using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
public class GetItemInfo{

	public static string path = "Item/GetImage";

	public static void ShowGetInfo(string ItemName){
		GameObject c =  GameObject.Instantiate (Resources.Load<GameObject>("Prefab/GetItemInfo"));
		c.GetComponent<Canvas> ().worldCamera = GameObject.Find ("Main Camera").GetComponent<Camera> ();
		var i = GameObject.Instantiate( Resources.Load<Sprite> (Path.Combine(path, ItemName)));
		c.transform.GetChild (0).GetChild (0).GetComponent<Image> ().sprite = i;
	}

	public static void ShowGetInfo(string ItemName,Action _callback){
		GameObject c =  GameObject.Instantiate (Resources.Load<GameObject>("Prefab/GetItemInfo"));
		c.GetComponent<Canvas> ().worldCamera = GameObject.Find ("Main Camera").GetComponent<Camera> ();
		var i = GameObject.Instantiate( Resources.Load<Sprite> (Path.Combine(path, ItemName)));
		c.transform.GetChild (0).GetChild (0).GetComponent<Image> ().sprite = i;
		_callback();
	}
	
}
