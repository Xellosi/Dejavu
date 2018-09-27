using UnityEngine;
using System.Collections;

public class scrollView : MonoBehaviour {


    Vector2 scrollPosition;
    Touch touch;
    // The string to display inside the scrollview. 2 buttons below add & clear this string.
    string longString = "This is a long-ish string";

    void OnGUI () { 

        scrollPosition = GUI.BeginScrollView(new Rect(110,50,100,200),scrollPosition, new Rect(110,50,1080,1920),GUIStyle.none,GUIStyle.none);

        for(int i = 0;i < 20; i++)
        {
            GUI.Box(new Rect(110,50+i*28,100,25),"xxxx_"+i);
        }
        GUI.EndScrollView ();
    }

    void Update()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.touches[0];
            if (touch.phase == TouchPhase.Moved)
            {
                scrollPosition.y += touch.deltaPosition.y;
            }
        }
    }
}