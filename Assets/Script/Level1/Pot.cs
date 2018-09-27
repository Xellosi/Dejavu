using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pot : MonoBehaviour {

	public Image soup;
	// Use this for initialization
	void Start () {
		if(PlayerDataManager.instance.data.Level1_Progress["PotThings"] == "Leg")
		soup.sprite = Resources.Load<Sprite>("Item/Level1/湯_蛙腳");
		else if(PlayerDataManager.instance.data.Level1_Progress["PotThings"] == "Leg,Spoon")
		soup.sprite = Resources.Load<Sprite>("Item/Level1/湯_蛙腳_湯匙");
		else if (PlayerDataManager.instance.data.Level1_Progress["PotThings"] == "Leg,Spoon,Seaweed")
		soup.sprite = Resources.Load<Sprite>("Item/Level1/湯_蛙腳_湯匙_海草");

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
