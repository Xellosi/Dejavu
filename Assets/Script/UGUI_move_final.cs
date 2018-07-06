using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UGUI_move_final :MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{

    [SerializeField]public GameObject grid = null;
    [SerializeField]public GameObject initCanvas = null;


    private bool collected=false;

    // Use this for initialization
    void Start()
    {
        grid = InventoryManager.Instance.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        p.z=0;
        transform.position=p;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.SetParent(initCanvas.transform, true);
        transform.GetComponent<CanvasGroup>().blocksRaycasts = false;
        transform.GetComponent<Image>().SetNativeSize();

        if(collected == false){
            collected=true;
            transform.SetParent(grid.transform);
            //call 對話欄顯示取得物品
        }  
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            if (eventData.pointerCurrentRaycast.gameObject.name == initCanvas.name || eventData.pointerCurrentRaycast.gameObject.name == grid.name)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
                transform.SetParent(grid.transform);
                transform.position = new Vector3(transform.position.x,transform.position.y,0f);
            }
        }
        transform.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

}

