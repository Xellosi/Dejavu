using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Weed : MonoBehaviour {

	// Use this for initialization
	public Image a;
	public int count=0;
	void Start () {
		if(PlayerDataManager.instance.data.Level1_Progress["Glass"]=="背包" || PlayerDataManager.instance.data.Level1_Progress["Glass"]=="消失"){
			//讓下面click無反應
			count=999;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void click(){
		if (count<4)
		count+=1;
		if(count==3 & PlayerDataManager.instance.data.Level1_Progress["Glass"]=="未出現"){
			a.sprite = Resources.Load<Sprite>("Item/Level1/隱藏草 - 開");
		}

		if(count==4 & PlayerDataManager.instance.data.Level1_Progress["Glass"]=="未出現"){
			GetItemInfo.ShowGetInfo("Glass",()=>{
			a.sprite = Resources.Load<Sprite>("Item/Level1/隱藏草");
			PlayerDataManager.instance.data.Level1_Progress["Glass"]="背包";
			GameObject glass = Instantiate(Resources.Load("Item/Level1/Glass", typeof(GameObject)) as GameObject);
			glass.transform.SetParent(GameObject.Find("BackGround").transform);
			glass.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
			glass.name = "Glass";
			glass.GetComponent<Glass>().PutInBag();
			});
		}
	}
}
