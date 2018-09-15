using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : ItemMoveBase {

	// Use this for initialization
	void Awake () {
		Init ();
		BackGround = GameObject.Find("BackGround");
		this.collected=true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
