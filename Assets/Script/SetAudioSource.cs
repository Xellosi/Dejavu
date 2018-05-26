using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAudioSource : MonoBehaviour
{

    public AudioSource AS;
    // Use this for initialization  
    void Start()
    {
        AS.loop = true;//设置声音为循环播放  
    }

    // Update is called once per frame  
    void Update()
    {
        DinosaurVoiceControl();

    }

    private void DinosaurVoiceControl()
    {
        if (AS != null)
        {
            if (Input.GetKey(KeyCode.P))
            {
                //按下按键P后进行播放  
                AS.Play();
            }
            else if (Input.GetKey(KeyCode.S))
            {
                //按下按键S停止播放  
                AS.Stop();
            }
        }

    }
}