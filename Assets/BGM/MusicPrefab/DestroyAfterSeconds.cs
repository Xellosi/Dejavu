using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour {
    public int second;
	// Use this for initialization
	void Start () {
        StartCoroutine(DestroyGameObject());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator DestroyGameObject()
    {
        yield return new WaitForSeconds(second);
        GameObject.Destroy(this.gameObject);
    }
}
