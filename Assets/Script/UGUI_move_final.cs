using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UGUI_move_final :MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{

    [SerializeField]public  GameObject grid = null;
    [SerializeField]public GameObject initCanvas = null;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 screenPoint = Input.mousePosition;
        screenPoint.z = 100.0f; //distance of the plane from the camera
        GetComponent<RectTransform>().pivot.Set(0, 0);
        transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        transform.SetParent(initCanvas.transform, true);
        transform.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            if (eventData.pointerCurrentRaycast.gameObject.name == grid.name)
            {
                transform.SetParent(grid.transform);
            }
        }
        transform.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

}

