using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public static OrderManager Instance { get; private set; }

    public GameObject costumerPrefab;
    public List<string> currentOrder = new List<string>();
    IngredientManager ingredient;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void setOrder(GameObject customer, List<string> order)
    {
        currentOrder = new List<string>(order); // replace old order with new order
        costumerPrefab = customer;
    }

    public void ClearOrder()
    {
        Debug.Log("Clearing the order and costumerPrefab...");
        costumerPrefab = null;
        currentOrder.Clear();
    }
}

