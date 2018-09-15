using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : ItemMoveBase {

	// Use this for initialization
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		Init ();
		BackGround = GameObject.Find("BackGround");
		this.collected=true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
