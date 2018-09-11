using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leg : ItemMoveBase {
	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		Init();
		BackGround = GameObject.Find("BackGround");
		this.collected=true;
	}
	void Start()
	{

	}
}
