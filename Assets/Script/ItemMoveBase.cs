﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class ItemMoveBase : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{

    [SerializeField] public GameObject grid = null;
    [SerializeField] public GameObject initCanvas = null;
    private Image _image;

    public bool DirectPick = true;
    public bool collected = false;
    public void Init()
    {
        grid = InventoryManager.Instance.transform.GetChild(0).GetChild(0).gameObject;
        _image = GetComponent<Image>();
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += checkinitC;
    }

    void checkinitC(Scene a, LoadSceneMode b)
    {
        if (initCanvas == null)
        {
            initCanvas = GameObject.Find("BackGround");
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
            if (eventData.pointerCurrentRaycast.gameObject.name == initCanvas.name)
            {
                _image.SetNativeSize();
            }
        }
        Debug.Log(collected);
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
            if (eventData.pointerCurrentRaycast.gameObject != null)
            {
                if (eventData.pointerCurrentRaycast.gameObject.name == initCanvas.name || eventData.pointerCurrentRaycast.gameObject.name == grid.name)
                {
                    transform.SetParent(grid.transform, true);
                }
                else if (true)
                {

                }
            }
            transform.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }
    public void PutInBag()
    {
        transform.SetParent(grid.transform, true);
    }
    public virtual void picking() {}
    public virtual void ProtectedPick() { }
}

