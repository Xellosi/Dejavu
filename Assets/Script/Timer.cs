using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Example());

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator Example()
    {
        print(Time.time);
        yield return new WaitForSeconds(5);
        print(Time.time);
    }
}
