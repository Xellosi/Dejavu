using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour {
    public static MusicControl Instance;

    
    [HideInInspector]
    public void GetInStoreSound()
    {
        if (GetInStore != null && play1 == false)
        {

            GameObject go = Instantiate(GetInStore, Vector2.zero, Quaternion.identity);
            play1 = true;

        }
    }
    [HideInInspector]
    public void NoEnergySound()
    {
        if (NoEnergy != null && play2 == false)
        {

            GameObject go = Instantiate(NoEnergy, Vector2.zero, Quaternion.identity);
            play2 = true;
        }
    }
    [HideInInspector]
    public void AddEnergyAndAwakeSound()
    {
        if (AddEnergyAndAwake != null && play3 == false)
        {

            GameObject go = Instantiate(AddEnergyAndAwake, Vector2.zero, Quaternion.identity);
            play3 = true;
        }
    }
    [HideInInspector]
    public void PickObjectSound()
    {
        if (PickObject != null && play4 == false)
        {

            GameObject go = Instantiate(PickObject, Vector2.zero, Quaternion.identity);
            play4 = true;
        }
    }
    [HideInInspector]
    public void BuySucessSound()
    {
        if (BuySucess != null && play5 == false)
        {

            GameObject go = Instantiate(BuySucess, Vector2.zero, Quaternion.identity);
            play5 = true;
        }
    }
    [HideInInspector]
    public void FoodInPotSound()
    {
        if (FoodInPot != null && play6 == false)
        {

            GameObject go = Instantiate(FoodInPot, Vector2.zero, Quaternion.identity);
            play6 = true;
        }
    }
    [HideInInspector]
    public void FoodInPot2Sound()
    {
        if (FoodInPot2 != null && play7 == false)
        {

            GameObject go = Instantiate(FoodInPot2, Vector2.zero, Quaternion.identity);
            play7 = true;
        }
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }


    [SerializeField] public GameObject NoEnergy = null;
    [SerializeField] public GameObject AddEnergyAndAwake = null;
    [SerializeField] public GameObject PickObject = null;
    [SerializeField] public GameObject BuySucess = null;
    [SerializeField] public GameObject FoodInPot = null;
    [SerializeField] public GameObject FoodInPot2 = null;
    [SerializeField] public GameObject GetInStore = null;

    bool play1 = false;

    bool play2 = false;
    bool play3 = false;
    bool play4 = false;
    bool play5 = false;
    bool play6 = false;
    bool play7 = false;

    
    

    
}
