﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class InventoryManager : MonoBehaviour {

	public static string PrefabPath = "Prefab/InventoryCanvas";
	private static InventoryManager _instance = null;
	private InventoryManager () {}
	private Button SettingButton;
	private GameObject Setting=null;

	public static InventoryManager Instance{
		get{
			if (_instance == null){
				GameObject manager = (GameObject)Instantiate(Resources.Load(PrefabPath));
				_instance = manager.GetComponent<InventoryManager>();
				_instance.GetComponent<Canvas>().worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
				DontDestroyOnLoad(manager);
			}
			return _instance;
		}
    }

	void OnEnable(){
		SceneManager.sceneLoaded += rendercameraupdate;
		SettingButton = transform.GetChild (0).GetChild (1).GetComponent<Button> ();
		SettingButton.onClick.AddListener (OpenSetting);
	}
	void rendercameraupdate(Scene a , LoadSceneMode b){
		if(this.GetComponent<Canvas>().worldCamera == null){
			this.GetComponent<Canvas>().worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
		}
	}

	void OpenSetting(){
		if (Setting == null) {
			Setting = (GameObject)Instantiate(Resources.Load ("Prefab/SettingCanvas"));
		} 
		else {
			Setting.SetActive (true);
		}
	}
}