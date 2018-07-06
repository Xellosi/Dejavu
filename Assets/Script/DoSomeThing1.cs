using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DoSomeThing1 : MonoBehaviour {

    DialogueManager a;
    InventoryManager b;
   void Start(){
       //DialogueManager.Instance.StartDialogue("test");
       b=InventoryManager.Instance;
   }
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
    public void GetSeaGrass()
    {

        StartCoroutine(TimeDelayer_SeaGrass());
    }

    float lastClick = 0;
    public void GetGloves()
    {
        if (lastClick + 2.5f < Time.time)
        {
            lastClick = Time.time;
            StartCoroutine(TimeDelayer_Gloves());
        }
    }
    public void ShowComputerUI()
    {

    }
    IEnumerator TimeDelayer_SeaGrass()
    {
        GameObject prefab = Resources.Load<GameObject>("章魚ui/1/UI設計/取得物品/Image");
        GameObject go = Instantiate(prefab);
        go.transform.parent = transform.parent;
        go.name = ("SeaGrass");
        GameObject change_Image = GameObject.Find("SeaGrass");
        change_Image.transform.localPosition = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(2);
        GameObject.Destroy(go);
    }
    IEnumerator TimeDelayer_Gloves()
    {
        GameObject prefab = Resources.Load<GameObject>("章魚ui/1/UI設計/取得物品/Glove");
        GameObject go1 = Instantiate(prefab);
        go1.transform.parent = transform.parent;
        go1.name = ("Gloves");
        GameObject change_Image1 = GameObject.Find("Gloves");
        change_Image1.transform.localPosition = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(10);
        GameObject.Destroy(go1);
    }
    IEnumerator TimeDelayer_Computer()
    {
        GameObject prefab = Resources.Load<GameObject>("章魚ui/1/UI設計/取得物品/Computer");
        GameObject go2 = Instantiate(prefab);
        go2.transform.parent = transform.parent;
        go2.name = ("Computer");
        GameObject change_Image1 = GameObject.Find("Computer");
        change_Image1.transform.localPosition = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(5);
        GameObject.Destroy(go2);
    }

}
