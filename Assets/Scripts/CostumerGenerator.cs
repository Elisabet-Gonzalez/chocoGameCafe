using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostumerGenerator : MonoBehaviour
{
    IngredientManager ing;
    
    [SerializeField] private GameObject[] normalCostumer;
    [SerializeField] private GameObject[] specialCostumer;


     void Start()
    {
       ing =  GameObject.Find("OrderLogic").GetComponent<IngredientManager>();

        
    }

    public void GenerateCostumer()
    {
        ing.GoRandom(3.5f, 0.46f, 0, normalCostumer);
        ing.Randomizer();

    }

    public void Bye()
    {
        ing.ClearAll();
    }

    //fortunately it is connected
    public void Test()
    {
        ing.Randomizer();
        Debug.Log("TeeHee");
    }
}
