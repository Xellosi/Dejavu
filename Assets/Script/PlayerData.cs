using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerData{
	#region Global
	public bool ALLclear;
	public bool[] Levelclear;
	#endregion

	//level1~4
	public int lastLevel;

	public SerializableDictionary<string, string> Level1_Progress = new SerializableDictionary<string, string>();
	public SerializableDictionary<string, string> Level2_Progress = new SerializableDictionary<string, string>();
	public SerializableDictionary<string, string> Level3_Progress = new SerializableDictionary<string, string>();
	public SerializableDictionary<string, string> Level4_Progress = new SerializableDictionary<string, string>();

}
