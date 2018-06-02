using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger_Eel : MonoBehaviour {

    [SerializeField] GameObject grid = null;

    void OnTriggerEnter2D(Collider2D Coll)
    {
        GameObject prefab = Resources.Load<GameObject>("章魚ui/1/prefab1/Eel");

        
        GameObject go = Instantiate(prefab,transform.position=new Vector3(-190,-140,-170), Quaternion.identity);
        
        go.transform.parent = transform.parent;

        GameObject change_position = GameObject.Find("Eel(Clone)");
        change_position.transform.SetParent(grid.transform);

        

        

    }

}

