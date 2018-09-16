//https://answers.unity.com/questions/890758/how-to-move-an-image-just-in-the-surface-of-the-ca.html
//TODO 限制滑鼠拖曳範圍
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class ItemMoveBase : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{

    [SerializeField] public GameObject Inventory = null;
    [SerializeField] public GameObject BackGround = null;
    private Image _image;

    public bool DirectPick = true;
    public bool collected = false;
    public void Init()
    {
        Inventory = InventoryManager.Instance.transform.GetChild(0).GetChild(0).gameObject;
        _image = GetComponent<Image>();
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += checkinitC;
    }

    void checkinitC(Scene a, LoadSceneMode b)
    {
        if (BackGround == null)
        {
            BackGround = GameObject.Find("BackGround");
        }
        //transform.position = new Vector3(transform.position.x,transform.position.y,0.0f);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (collected == true)
        {
            Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            p.z = 0f;
            transform.position = p;
            if (eventData.pointerCurrentRaycast.gameObject.name == BackGround.name)
            {
                _image.SetNativeSize();
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (DirectPick == true & collected == false)
        {
            PutInBag();
            picking();
        }
        else if (DirectPick == false & collected == false)
        {
            ProtectedPick();
        }
        else if (collected == true)
        {
            transform.SetParent(InventoryManager.Instance.transform, true);
            transform.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (collected == true)
        {
            var GroundObj = eventData.pointerCurrentRaycast.gameObject;
            if (GroundObj != null)
            {
                if (GroundObj.name == BackGround.name)
                {
                    transform.SetParent(Inventory.transform, true);
                }
                else if (GroundObj.name == Inventory.name)
                {
                    Debug.Log("查看說明" + gameObject.name);
                }
                else
                {
                    Debug.Log(gameObject.name+","+GroundObj.name);
                    if (GameManager.Instance._LevelControl.CollideEvent[gameObject.name + "," + GroundObj.name] != "")
                    {
                        GameManager.Instance._LevelControl.CallCollideEvent(GameManager.Instance._LevelControl.CollideEvent[gameObject.name + "," +
                        GroundObj.name], gameObject, GroundObj);
                    }
                    else
                        PutInBag();
                }
            }
            transform.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }
    public void PutInBag()
    {
        transform.SetParent(Inventory.transform, true);
    }
    public virtual void picking() { }
    public virtual void ProtectedPick() { }
}

