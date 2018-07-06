using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerData{

    [SerializeField]
    public List<int> NumList;
    [SerializeField]
    public int[] NumArray;
    [SerializeField]
    public SerializableDictionary<string, bool> Progress = new SerializableDictionary<string, bool>();

}
