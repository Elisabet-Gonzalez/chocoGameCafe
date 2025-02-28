using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class IngredientManager : MonoBehaviour
{
    [SerializeField] GameObject theBubble;
    GameObject copyBubble;
    [SerializeField] private GameObject[] temp;
    [SerializeField] private GameObject[] flavor;
    [SerializeField] private GameObject[] toppings;

    public string[] order;


    public List<string> orderList = new List<string>();
    private List<GameObject> spawnedObjects = new List<GameObject>();

    public void GoRandom(float x, float y, float z, GameObject[] array)
    {
        int randomNum = Random.Range(0, array.Length);
        GameObject spawnedObject = Instantiate(array[randomNum], new Vector3(x, y, z), Quaternion.identity);

        spawnedObjects.Add(spawnedObject);

        string currentObject = spawnedObject.name.Replace("(Clone)", "").Trim();

        orderList.Add(currentObject);

    }
    public void ClearAll()
    {
        for (int i = 0; i < spawnedObjects.Count; i++)
        {
            Destroy(spawnedObjects[i]);
        }
        Destroy(copyBubble);
        spawnedObjects.Clear();
        orderList.Clear();
    }
    public void Randomizer()
    {
        ClearAll(); //no es eso

        copyBubble = Instantiate(theBubble, new Vector3(-0.85f, 2.55f, -1f), Quaternion.identity);
        GoRandom(-2.65f, 2.6f, -2f, temp);
        GoRandom(-1.3f, 2.6f, -2f, flavor);
        GoRandom(0f, 2.6f, -2f, toppings);
        GoRandom(1f, 2.6f, -2f, toppings);




    }



    public void RecreateOrder(List<string> order)
    {
        ClearAll();

        copyBubble = Instantiate(theBubble, new Vector3(-0.85f, 2.55f, -1f), Quaternion.identity);

        bool firstTopping = true;

        foreach (string ingredient in order)
        {
            if (IngredientInArray(ingredient, temp))
            {
                SpawnVisual(-2.65f, 2.6f, -2f, temp, ingredient);
            }
            else if (IngredientInArray(ingredient, flavor))
            {
                SpawnVisual(-1.3f, 2.6f, -2f, flavor, ingredient);

            }
            else if (IngredientInArray(ingredient, toppings))
            {
                float xPos = firstTopping ? 0f : 1f;
                SpawnVisual(xPos, 2.6f, -2f, toppings, ingredient);

                firstTopping = false;
            }

        }


            Debug.Log("Recreated Order: " + string.Join(", ", order));
        }

        private bool IngredientInArray(string ingredient, GameObject[] array)
        {
            foreach (GameObject obj in array)
            {
                if (obj.name == ingredient)
                {

                    return true;
                }
            }
            return false;

        }

        private void SpawnVisual(float x, float y, float z, GameObject[] ingredients, string name)
        {
            foreach (var ingredient in ingredients)
            {
                if (ingredient.name == name)
                {
                    GameObject spawnedObject = Instantiate(ingredient, new Vector3(x, y, z), Quaternion.identity);
                    spawnedObjects.Add(spawnedObject);

                    orderList.Add(name);

                    break;

                }
            }
        }
    } 
    