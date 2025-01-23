using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class IngredientManager : MonoBehaviour
{
    [SerializeField] private GameObject[] temp;
    [SerializeField] private GameObject[] flavor;
    [SerializeField] private GameObject[] toppings;
    

    public void GoRandom(float x, float y, float z,GameObject[] array)
    {
       int randomNum = Random.Range(0, array.Length);
        Instantiate(array[randomNum], new Vector3(x,y,z), Quaternion.identity);
        Debug.Log(array[randomNum]);
    }



    public void Randomizer()
    { 
        GoRandom(-2.65f,2.6f,-2f, temp);
        GoRandom(-1.3f, 2.6f, -2f, flavor);
        GoRandom(0f,2.6f,-2f, toppings);
        
        int numC = Random.Range(0, 2);
        if (numC == 0)
        {
            GoRandom(1f,2.6f, -2f, toppings);
        }
        
    }
}
