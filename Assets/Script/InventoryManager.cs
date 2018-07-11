using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InventoryManager : MonoBehaviour {

	public static string PrefabPath = "Prefab/InventoryCanvas";
	private static InventoryManager _instance = null;
	private InventoryManager () {}


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
	}
	void rendercameraupdate(Scene a , LoadSceneMode b){
		if(_instance.GetComponent<Canvas>().worldCamera == null){
			_instance.GetComponent<Canvas>().worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
		}
	}
}
