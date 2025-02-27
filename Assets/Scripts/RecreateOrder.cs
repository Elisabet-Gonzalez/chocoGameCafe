using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecreateOrder : MonoBehaviour
{
    [SerializeField] private IngredientManager ing;

    private void Start()
    {

        ing = GameObject.Find("OrderLogic").GetComponent<IngredientManager>();

       



        if (OrderManager.Instance.currentOrder.Count > 0)
        {
            RecreateCosAndOrder();
            Debug.Log("Recreate the order");

            
            
        }
    }

    private void RecreateCosAndOrder()
    {
        if (OrderManager.Instance.costumerPrefab != null)
        {
            Instantiate(OrderManager.Instance.costumerPrefab, new Vector3(3.5f,0.46f, 0f), Quaternion.identity);

        }



        ing.RecreateOrder(OrderManager.Instance.currentOrder);
    }



    




}
