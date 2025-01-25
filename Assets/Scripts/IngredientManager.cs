using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class IngredientManager : MonoBehaviour
{
    [SerializeField] GameObject theBubble;
    GameObject copyBubble;
    [SerializeField] private GameObject[] temp;
    [SerializeField] private GameObject[] flavor;
    [SerializeField] private GameObject[] toppings;
    private List<GameObject> spawnedObjects = new List<GameObject>();
    
    public void GoRandom(float x, float y, float z, GameObject[] array)
    {
        int randomNum = Random.Range(0, array.Length);
        GameObject spawnedObject = Instantiate(array[randomNum], new Vector3(x, y, z), Quaternion.identity);
        spawnedObjects.Add(spawnedObject);
        Debug.Log(spawnedObject);

    }

    public void ClearAll()
    {
        for (int i = 0; i < spawnedObjects.Count; i++)
        {
            Destroy(spawnedObjects[i]);
        }
        Destroy(copyBubble);
        spawnedObjects.Clear(); 
    }
    public void Randomizer()
    {
        copyBubble = Instantiate(theBubble, new Vector3 (-0.85f, 2.55f, -1f), Quaternion.identity);
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
