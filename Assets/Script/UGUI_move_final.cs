using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class UGUI_move_final :MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{

    [SerializeField]public GameObject grid = null;
    [SerializeField]public GameObject initCanvas = null;


    private bool collected=false;

    void Start(){
        grid = InventoryManager.Instance.transform.GetChild(0).gameObject;
    }
    void OnEnable(){
        SceneManager.sceneLoaded += checkinitC;
    }
    // Use this for initialization
    // Update is called once per frame

    void checkinitC(Scene a , LoadSceneMode b){
        if (initCanvas==null){
            initCanvas = GameObject.Find("BackGround");
        }
        //transform.position = new Vector3(transform.position.x,transform.position.y,0.0f);
    }
    void Update()
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        p.z=0f;
        transform.position=p;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.SetParent(transform.parent.parent, true);
        transform.GetComponent<CanvasGroup>().blocksRaycasts = false;
        if(collected == false){
            collected=true;
            transform.SetParent(grid.transform,true);
            //call 對話欄顯示取得物品
        }  
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            Debug.Log(eventData.pointerCurrentRaycast.gameObject.name );
            if (eventData.pointerCurrentRaycast.gameObject.name == initCanvas.name || eventData.pointerCurrentRaycast.gameObject.name == grid.name)
            {
                transform.SetParent(grid.transform,true);
            }
        }
        transform.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

}

