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


    [SerializeField]
    public List<int> NumList;
    [SerializeField]
    public int[] NumArray;
    [SerializeField]
    public SerializableDictionary<string, bool> Level1_Progress = new SerializableDictionary<string, bool>();
	public SerializableDictionary<string, bool> Level2_Progress = new SerializableDictionary<string, bool>();
	public SerializableDictionary<string, bool> Level3_Progress = new SerializableDictionary<string, bool>();
	public SerializableDictionary<string, bool> Level4_Progress = new SerializableDictionary<string, bool>();

}
