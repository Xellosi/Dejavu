using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger : MonoBehaviour {

    

    void OnTriggerEnter2D(Collider2D Coll)
    {
        GameObject prefab = Resources.Load<GameObject>("章魚ui/a");

        
        GameObject go = Instantiate(prefab,transform.position=new Vector3(-190,-140,-170), Quaternion.identity);
        
        go.transform.parent = transform.parent;

        GameObject change_position = GameObject.Find("a(Clone)");
        change_position.transform.localPosition = new Vector3(196, 10, 0);


       


    }

}

