using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
public class ControlBase : MonoBehaviour {
	//Dictionary of the two objects which collided
	public Dictionary< string,Action<GameObject,GameObject>> DramaActions = new Dictionary<string,Action<GameObject,GameObject>>();
	//The look up Dictionary which map actionName and function
	public Dictionary< string,Action<GameObject,GameObject>> EventTable = new Dictionary<string, Action<GameObject, GameObject>>();

	public virtual void Init(){}
	public virtual void SaveInit(){}
}
