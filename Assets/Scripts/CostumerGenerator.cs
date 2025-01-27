using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostumerGenerator : MonoBehaviour
{
    IngredientManager ingredientManager;
    
    [SerializeField] private GameObject[] normalCostumer;
    [SerializeField] private GameObject[] specialCostumer;


     void Start()
    {
       ingredientManager =  GameObject.Find("OrderLogic").GetComponent<IngredientManager>();

        
    }

    public void GenerateCostumer()
    {
        ingredientManager.GoRandom(3.5f, 0.46f, 0, normalCostumer);
        ingredientManager.Randomizer();

    }

    public void Bye()
    {
        ingredientManager.ClearAll();
    }

    //fortunately it is connected
    public void Test()
    {
        ingredientManager.Randomizer();
        Debug.Log("TeeHee");
    }
}
