using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    public Sprite[] toppingSprites;
    public Transform toppingLayer;
    [SerializeField] private float yNum;
    [SerializeField] private float xNum;
    private bool onArea = false;
    ChangeOnTouch change;
   

    private ParticleSystem particleSys;

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



        if(other.gameObject.name == "cookieCrumbl" && onArea && change.milkReady)
        {
            AddTopping(toppingSprites[0], yNum,-2);
        }

        if(other.gameObject.name == "CrmelCrunch" && onArea && change.milkReady)
        {
            AddTopping(toppingSprites[1], yNum, -2);
        }

        if(other.gameObject.name == "ChocoChips" && onArea && change.milkReady)
        {
            AddTopping(toppingSprites[2], yNum, -2);
        }

        if(other.gameObject.name == "ChocoSyrup" && onArea && change.milkReady)
        {
            AddTopping(toppingSprites[3], yNum, -2);
        }

        if (other.gameObject.name == "StrawberrySyrup" && onArea && change.milkReady)
        {
            AddTopping(toppingSprites[4], yNum, -2);

        }

        if(other.gameObject.name == "cream" && onArea && change.milkReady)
        {
            AddTopping(toppingSprites[5], yNum, -1);
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
