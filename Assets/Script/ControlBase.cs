using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
public class ControlBase : MonoBehaviour {
	//Dictionary of the two objects which collided
	public Dictionary< string,string> CollideEvent = new Dictionary<string,string>();
	//The look up Dictionary which map actionName and function
	public virtual void LevelStart(){}
	public virtual SerializableDictionary<string,string> SaveInit(){return null;}

	public virtual void CallCollideEvent(string name,GameObject hold, GameObject ground){
        
    }
}
