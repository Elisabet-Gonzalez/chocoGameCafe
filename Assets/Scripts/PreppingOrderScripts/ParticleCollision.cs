using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    [SerializeField] PlayerDrink drink;
    public Sprite[] toppingSprites;
    public Transform toppingLayer;
    [SerializeField] private float yNum;
    [SerializeField] private float xNum;
    private bool onArea = false;
    ChangeOnTouch change;
    public int counter = 0;

    private ParticleSystem particleSys;

    public void Drink(PlayerDrink d)
    {
        drink = d;
    }


    private void Start()
    {
        change = GetComponent<ChangeOnTouch>();
        Debug.Log(change);
    }



    private void OnTriggerEnter2D(Collider2D other)
    { 

        if(other.gameObject.name == "ToppingArea")
        {
            onArea = true;
            Debug.Log(onArea);
        }



        if(other.gameObject.name == "cookieCrumbl" && onArea && change.milkReady && counter < 2)
        {
            AddTopping(toppingSprites[0], yNum,-2);
            counter++;
            drink.AddIngredient("CookieCrumbl");
        }

        if(other.gameObject.name == "CrmelCrunch" && onArea && change.milkReady && counter < 2)
        {
            AddTopping(toppingSprites[1], yNum, -2);
            counter++;
            drink.AddIngredient("CaramelCrunch");
        }

        if(other.gameObject.name == "ChocoChips" && onArea && change.milkReady && counter < 2)
        {
            AddTopping(toppingSprites[2], yNum, -2);
            counter++;
            drink.AddIngredient("ChocoChips");
        }

        if(other.gameObject.name == "ChocoSyrup" && onArea && change.milkReady && counter < 2)
        {
            AddTopping(toppingSprites[3], yNum, -2);
            counter++;
            drink.AddIngredient("ChocoSyrup");
        }

        if (other.gameObject.name == "StrawberrySyrup" && onArea && change.milkReady && counter < 2)
        {
            AddTopping(toppingSprites[4], yNum, -2);   
            counter++;
            drink.AddIngredient("StrawberrySyrup");

        }

        if(other.gameObject.name == "cream" && onArea && change.milkReady && counter < 2)
        {
            AddTopping(toppingSprites[5], yNum, -1);    
            counter++;
            drink.AddIngredient("WhippedCream");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "ToppingArea")
        {
            onArea = false;
            Debug.Log(onArea);
        }
    }


    private void AddTopping(Sprite toppingSprite, float yNum, float zNum)
    {
        Debug.Log("adding");
        GameObject toppingObject = new GameObject("Topping");
        toppingObject.transform.position = transform.position;

        toppingObject.transform.SetParent(transform);

        float yOffset = yNum;
        toppingObject.transform.localPosition = new Vector3(xNum, yOffset, zNum);


        SpriteRenderer renderer = toppingObject.AddComponent<SpriteRenderer>(); 
        renderer.sprite = toppingSprite;

        renderer.sortingOrder = toppingLayer.childCount;
    }

    
    
}
