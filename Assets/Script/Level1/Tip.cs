using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tip : MonoBehaviour {
	public void ClickTip(){
		if (PlayerDataManager.instance.data.Level1_Progress["Tip"]=="關閉")
		DialogueManager.Instance.StartDialogue("未收集完_提示");
		else if (PlayerDataManager.instance.data.Level1_Progress["Tip"]=="開啟")
		DialogueManager.Instance.StartDialogue("收集完_提示");
	}
}
