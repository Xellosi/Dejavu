using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DoSomeThing1 : MonoBehaviour {
    [SerializeField] GameObject grid = null;
    public void ChangeImagePosition()
    {

        GameObject change_Image = GameObject.Find("GameObject");
        change_Image.transform.localPosition = new Vector3(194, -50, 0);
    }
    public void ChangeImageObjectSprite()
    {
        Sprite sprite = Resources.Load<Sprite>("Sprite/提示紙");
        /*  GameObject go = GameObject.Find("abc");
          Image img = go.GetComponent<Image>();
          img.sprite = sprite;*/
        GameObject.Find("black").GetComponent<Image>().sprite = sprite;
    }
    
    public void ChangeSeaGrassPosition()
    {

        GameObject change_Image1 = GameObject.Find("blackspace");

        
        change_Image1.transform.SetParent(grid.transform);
    }

}
