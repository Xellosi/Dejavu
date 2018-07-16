using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TitleControl : MonoBehaviour {
	Button b;
	// Use this for initialization
	void Start () {
		b = GetComponent<Button> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void ClosePanel(){
		transform.parent.gameObject.SetActive (false);
	}

	public void OpenPanel(GameObject a){
		a.SetActive (true);
	}
}
