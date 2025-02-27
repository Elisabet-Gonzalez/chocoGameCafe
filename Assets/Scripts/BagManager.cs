using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagManager : MonoBehaviour
{
    public static BagManager Instance {  get; private set; }

    public GameObject bag;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("Bag Manager");
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        bag.SetActive(false);
    }

    public void ShowBag()
    {
        if(bag != null)
        {
            bag.SetActive(true);
            Debug.Log("Bag shown");
        }
        else
        {
            Debug.Log("nono");
        }


    }

    public void HideBag()
    {
        if(bag != null)
        {
            bag.SetActive(false);
            Debug.Log("Bag Hidden");
        }
        else
        {
            Debug.Log("No bag reference");
        }
    }




}
