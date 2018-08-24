using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class InventoryManager : MonoBehaviour {

	public static string PrefabPath = "Prefab/InventoryCanvas";
	private static InventoryManager _instance = null;
	private InventoryManager () {}
	public Button setting;

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
		setting = transform.GetChild (0).GetChild (1).GetComponent<Button> ();
	}
	void rendercameraupdate(Scene a , LoadSceneMode b){
		if(this.GetComponent<Canvas>().worldCamera == null){
			this.GetComponent<Canvas>().worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
		}
	}

	void OpenSetting(){
		setting = transform.GetChild (0).GetChild (1).GetComponent<Button> ();
	}
}
