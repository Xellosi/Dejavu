using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameManager : MonoBehaviour {
	
	public enum GameState { Title,Level1,Level2,Level3,Level4 };
	public GameState CurrentState;
	// Use this for initialization
	void Start () {
		CurrentState = GameState.Title;
		Debug.Log (CurrentState);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
