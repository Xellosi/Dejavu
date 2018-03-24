using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FitScreenSize : MonoBehaviour {

    RectTransform imageTransform;
    Image image;
    public bool FitHeight;
    public bool FitWidth;
    // Use this for initialization
    void Start()
    {
        //從自身GameObject上找出RectTransform這個模組
        imageTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        //Debug.Log("width :" + Screen.width);
        // Debug.Log("height :" + Screen.height);
    }

    // Update is called once per frame
    void Update()
    {
        FitScreenWidthAndHeight();
    }

    //會變形的Fit
    public void FitScreen()
    {
        //確定真的有RectTransform
        if (imageTransform != null)
        {
            //檢查現在的大小是否需要更改
            if (imageTransform.sizeDelta.x == Screen.width && imageTransform.sizeDelta.y == Screen.height)
            {
                //不需要更改，回傳
                return;
            }
            //需要更改
            //取得熒幕寬
            float width = Screen.width;
            //取得熒幕高
            float height = Screen.height;
            //更改大小
            imageTransform.sizeDelta = new Vector2(width, height);
        }
    }

    public void FitScreenWidth()
    {
        image.SetNativeSize();
        float widthToHeightRatio = imageTransform.sizeDelta.x / imageTransform.sizeDelta.y;
        float width = Screen.width;
        float height = width / widthToHeightRatio;
        imageTransform.sizeDelta = new Vector2(width, height);
    }
    public void FitScreenHeight()
    {
        image.SetNativeSize();
        float widthToHeightRatio = imageTransform.sizeDelta.x / imageTransform.sizeDelta.y;
        float height = Screen.height;
        float width = height * widthToHeightRatio;
        imageTransform.sizeDelta = new Vector2(width, height);
    }

    public void FitScreenWidthAndHeight()
    {
        image.SetNativeSize();
        float widthToHeightRatio = imageTransform.sizeDelta.x / imageTransform.sizeDelta.y;
        float screenRatio = Screen.width / Screen.height;
        if (widthToHeightRatio < screenRatio)
        {
            FitScreenHeight();
        }
        else
        {
            FitScreenWidth();
        }

    }

}
