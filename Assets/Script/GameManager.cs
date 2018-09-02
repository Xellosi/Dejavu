//Enum https://social.msdn.microsoft.com/Forums/vstudio/en-US/3160521c-3260-4b8c-8f99-a9e6842c164f/get-enum-by-index?forum=csharpgeneral

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
	
	public enum GameState { Title,Level1,Level2,Level3,Level4 };
	public GameState CurrentState;
	public MonoBehaviour _LevelControl;
	public List<string> _Levelevents;


	private static GameManager _instance;
	private GameManager(){
	}

	public static GameManager Instance{
		get{
			if (_instance == null) {
				GameObject p = (GameObject)Instantiate(Resources.Load("Prefab/GameManager"));
				_instance = p.GetComponent<GameManager>();
			}
			return _instance;
		}
	}
	public void Awake() {
		DontDestroyOnLoad(gameObject);
		_instance = this;
		Debug.Log ((GameState)1);
	}

	// Use this for initialization
	void Start () {
		CurrentState = GameState.Title;
		//load player global save

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadNewLevel1(){
		var control1 = this.gameObject.AddComponent<Level1Control> (); //把level控制抓進GameManager
		PlayerDataManager.instance.Level1_Progress = control1.Level1SaveInit ();//Control裡寫進所有Progress的初始狀態
		SceneManager.LoadScene(1);
		this.CurrentState=GameState.Level1;
	}
	public void LoadNewLevel2(){

	}
	public void LoadNewLevel3(){

	}
	public void LoadNewLevel4(){

	}
	public void LoadLastGame(){
		if (_LevelControl!=null)
			Destroy(_LevelControl);
		switch (PlayerDataManager.instance.data.lastLevel) {
		case 1:
			_LevelControl = this.gameObject.AddComponent<Level1Control> ();
			break;
		case 2:
			_LevelControl = this.gameObject.AddComponent<Level2Control>();
			break;
		case 3:
			_LevelControl = this.gameObject.AddComponent<Level3Control>();
			break;
		case 4:
			_LevelControl = this.gameObject.AddComponent<Level4Control>();
			break;
		}
		PlayerDataManager.instance.LoadPlayerData ();
		SceneManager.LoadScene(PlayerDataManager.instance.data.lastLevel);
		SceneManager.sceneLoaded +=(arg0, arg1) => this.CurrentState=(GameState)PlayerDataManager.instance.data.lastLevel;
	}
}
