using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetEel : MonoBehaviour {
    public GameObject glove_position;
    // Use this for initialization
    void Start () {
		glove_position = GameObject.Find("GloveObj");
	}
    int number = 1;
	// Update is called once per frame
	void Update () {
        if (glove_position.transform.localPosition != new Vector3(116, -258, 0) )
            {
            while (number < 2)
            {
                StartCoroutine(TimeDelayer_Gloves());
                number++;
            }
        }
        
    }
    IEnumerator TimeDelayer_Gloves()
    {
        GameObject prefab = Resources.Load<GameObject>("章魚ui/1/UI設計/取得物品/Glove");
        GameObject go1 = Instantiate(prefab);
        go1.transform.parent = transform.parent;
        go1.name = ("Glovess");
        GameObject change_Image1 = GameObject.Find("Glovess");
        change_Image1.transform.localPosition = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(2);
        GameObject.Destroy(go1);
    }
}
