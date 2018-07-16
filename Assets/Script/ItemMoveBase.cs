using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class ItemMoveBase :MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{

    [SerializeField]public GameObject grid = null;
	private Image _image;
    private bool collected=false;


    public void OnDrag(PointerEventData eventData)
    {
        Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        p.z=0f;
        transform.position=p;
		if (eventData.pointerCurrentRaycast.gameObject.name == "BackGround") {
			_image.SetNativeSize ();
		}
    }

    public void OnPointerDown(PointerEventData eventData)
    {
		transform.SetParent(InventoryManager.Instance.transform, true);
        transform.GetComponent<CanvasGroup>().blocksRaycasts = false;
        if(collected == false){
            collected=true;
            transform.SetParent(grid.transform,true);
        }  
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
			if (eventData.pointerCurrentRaycast.gameObject.name == "BackGround" || eventData.pointerCurrentRaycast.gameObject.name == grid.name)
            {
                transform.SetParent(grid.transform,true);
            }
        }
        transform.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

	public void Init(){
		_image = GetComponent<Image> ();
		grid = InventoryManager.Instance.transform.GetChild(0).gameObject;
	}
}

