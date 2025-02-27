using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CostumerGenerator : MonoBehaviour
{
   [SerializeField] IngredientManager ing;
    
    [SerializeField] private GameObject[] normalCostumer;
    [SerializeField] private GameObject[] specialCostumer;
   [SerializeField] private GameObject spawnedObject;

    private void Start()
    {
         ing = GameObject.Find("OrderLogic").GetComponent<IngredientManager>();
    }




    public void GenerateCostumer()
    {

        ing.Randomizer();

        spawnedObject = CostumRandom(3.5f, 0.46f, 0f, normalCostumer);
        
        if (spawnedObject != null)
        {

            Debug.Log("No te gira el chicharo");
        }
        else
        {


            OrderManager.Instance.setOrder(spawnedObject, ing.orderList);
            
        }
        
    }

    public void Bye()
    {
        ing.ClearAll();
        Destroy(spawnedObject);
    }

    private GameObject CostumRandom(float x, float y, float z, GameObject[] array)
    {
        int randomNum = Random.Range(0, array.Length);
         return Instantiate(array[randomNum], new Vector3(x, y, z), Quaternion.identity);
        
        
    }

}
