using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spoon : ItemMoveBase {

	// Use this for initialization
	void Start () {
		Init ();
		if (PlayerDataManager.instance.data.Level1_Progress["Spoon"] == "消失" || PlayerDataManager.instance.data.Level1_Progress["Spoon"] == "包包")
        {
            Destroy(this.gameObject);
            return;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
