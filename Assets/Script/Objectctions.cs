using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectctions{

	public static void DeleteFrist (GameObject a, GameObject b){
		GameObject.Destroy (a);
	}

	public static void DeleteSec(GameObject a, GameObject b){
		GameObject.Destroy (b);
	}
}
