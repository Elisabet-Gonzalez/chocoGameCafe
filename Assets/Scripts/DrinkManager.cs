using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkManager : MonoBehaviour
{
    //idk what does that do
    public static DrinkManager Instance
        {
        get;
        private set;
        }

    private GameObject curDrink;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool SpawnDrink(GameObject newDrink)
    {
        if (curDrink != null)
        {
            Debug.Log("Opps, there is a drink already");
            return false;
        }

        curDrink = newDrink;
        return true;
    }

   public void RemoveDrink()
    {

    curDrink = null;
    }
}
