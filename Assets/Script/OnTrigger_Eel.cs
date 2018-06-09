using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger_Eel : MonoBehaviour {

    
    [SerializeField]public GameObject grid1 = null;
    [SerializeField]public GameObject gridInt = null;
    void OnTriggerEnter2D(Collider2D Coll)
    {
        GameObject prefab = Resources.Load<GameObject>("章魚ui/1/prefab1/Eel");

        
        GameObject go = Instantiate(prefab,transform.position=new Vector3(-190,-140,-170), Quaternion.identity);
        UGUI_move_final move=   go.AddComponent<UGUI_move_final>();
        move.grid = grid1;
        move.initCanvas = gridInt;
        CanvasGroup CanGroup =go.AddComponent<CanvasGroup>();

        go.transform.parent = transform.parent;

        GameObject change_position = GameObject.Find("Eel(Clone)");
        change_position.transform.SetParent(grid1.transform);

        GameObject FindEel = GameObject.Find("ElectricEel");
        GameObject.Destroy(FindEel);                //電鰻進背包



        GameObject prefab1 = Resources.Load<GameObject>("章魚ui/1/prefab1/Spoon");


        GameObject go1 = Instantiate(prefab1, transform.position = new Vector3(-190, -140, -170), Quaternion.identity);

        go1.transform.parent = transform.parent;
        GameObject change_position1 = GameObject.Find("Spoon(Clone)");
        Debug.Log(change_position1);
        Debug.Log(change_position1.transform);
        Debug.Log(grid1);
        Debug.Log(grid1.transform);


        change_position1.transform.SetParent(grid1.transform);

        GameObject FindSpoon = GameObject.Find("spoons");
        GameObject.Destroy(FindSpoon);




    }

}

