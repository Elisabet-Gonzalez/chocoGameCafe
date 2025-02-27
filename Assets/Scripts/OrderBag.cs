using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderBag : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "OrderReturnArea")
        {
            Debug.Log("Drink placed");
            PlayerDrink.Instance.SubmitDrink();
        }
    }




}
