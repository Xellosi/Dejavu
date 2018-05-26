using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUI : MonoBehaviour {

    public bool WindowShow = false;
    void OnGUI()
    {
        if (GUI.Button(new Rect(310, 10, 80, 30), "暂停"))
        {
            if (WindowShow)
                WindowShow = false;
            else
                WindowShow = true;
        }
        
    }
}
