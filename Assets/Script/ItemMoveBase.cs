using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class ItemMoveBase :MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{

    [SerializeField]public GameObject grid = null;
    [SerializeField]public GameObject initCanvas = null;
	private Image _image;

    private bool collected=false;

    public void Init(){
		grid = InventoryManager.Instance.transform.GetChild(0).GetChild(0).gameObject;
		_image = GetComponent<Image> ();
    }
    void OnEnable(){
        SceneManager.sceneLoaded += checkinitC;
    }

    void checkinitC(Scene a , LoadSceneMode b){
        if (initCanvas==null){
            initCanvas = GameObject.Find("BackGround");
        }
        //transform.position = new Vector3(transform.position.x,transform.position.y,0.0f);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        p.z=0f;
        transform.position=p;
		if (eventData.pointerCurrentRaycast.gameObject.name == initCanvas.name) {
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
            if (eventData.pointerCurrentRaycast.gameObject.name == initCanvas.name || eventData.pointerCurrentRaycast.gameObject.name == grid.name)
            {
                transform.SetParent(grid.transform,true);
            }
        }
        transform.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}

