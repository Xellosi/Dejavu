using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TitleButtons : MonoBehaviour {
	// Use this for initialization
	void Start () {
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
	public void NewGame(){
		GameManager.Instance.LoadNewLevel1 ();
	}
	public void LoadGame(){
		GameManager.Instance.LoadLastGame ();
	}
}
