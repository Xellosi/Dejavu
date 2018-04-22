using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour {

    public Camera ca;
    private Ray ra;
    private RaycastHit hit;
    private int flag = 0;
    private object main;


    // Use this for initialization  
    void Start()
    {

    }

    // Update is called once per frame  
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ra = ca.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ra, out hit))
            {
                if (flag == 0)
                {
                    flag = 1;
                }
                else
                {
                    flag = 0;
                }
            }
        }
        if (flag == 1)
        {
            var a = ca.ScreenToWorldPoint(Input.mousePosition);
            hit.collider.gameObject.transform.position = new Vector3(a.x,a.y,hit.collider.gameObject.transform.position.z);
        }

    }
}
