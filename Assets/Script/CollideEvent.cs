using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//https://forum.unity.com/threads/display-scriptableobjects-in-an-array-in-inspector.51642/
[System.Serializable]
public class CollideEvent {
	[HideInInspector]public string Objects;
	public string FunctionName;

	public CollideEvent(string name){
		this.Objects = name;
	}
}