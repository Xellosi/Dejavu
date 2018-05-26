using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_down : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void movingdown () {
        transform.position += Vector3.down * 2 * Time.deltaTime;
	}
}
