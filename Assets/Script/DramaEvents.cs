using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class DramaEvents
{
	[HideInInspector]public string name;
	public List<string> events = new List<string>();

	public DramaEvents(string name){
		this.name = name;
	}
}