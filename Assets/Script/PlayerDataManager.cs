using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class PlayerDataManager : MonoBehaviour {

    #region Singleton

    private static PlayerDataManager _instance;

    public static PlayerDataManager instance {
        set {
            _instance = value;
        }
        get {
            if (_instance == null) {
                GameObject player = (GameObject)Instantiate(Resources.Load("Prefab/PlayerData"));
                _instance = player.GetComponent<PlayerDataManager>();
                _instance.LoadPlayerData();
            }
            return _instance;
        }
    }
		
    private PlayerDataManager() {
    }

    public void Awake() {
        DontDestroyOnLoad(gameObject);
        _instance = this;
    }
    #endregion

    public PlayerData data;
	private bool IsLoaded = false;

    public SerializableDictionary<string, string> Level1_Progress {
		get { return data.Level1_Progress; }
		set { data.Level1_Progress = value; }
    }
	public SerializableDictionary<string, string> Level2_Progress {
		get { return data.Level2_Progress; }
		set { data.Level2_Progress = value; }
	}
	public SerializableDictionary<string, string> Level3_Progress {
		get { return data.Level3_Progress; }
		set { data.Level3_Progress = value; }
	}
	public SerializableDictionary<string, string> Level4_Progress {
		get { return data.Level4_Progress; }
		set { data.Level4_Progress = value; }
	}

    public void Start() {
        //Load
        LoadPlayerData();
    }

    public void LoadPlayerData() {
        if(IsLoaded == true) {
            return;
        }
        string savePath;
        savePath = Path.Combine(Application.persistentDataPath, "PlayerSave.xml");
        if (File.Exists(savePath)) {
            data = XMLManager.Load<PlayerData>(savePath);
        }
        IsLoaded = true;
    }

    public void SavePlayerData() {
        string savePath;
        savePath = Path.Combine(Application.persistentDataPath, "PlayerSave.xml");
        Debug.Log(savePath);
        XMLManager.Save<PlayerData>(data, savePath);
    }

}
