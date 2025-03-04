using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.Device;

public class OriginalObject : MonoBehaviour
{
    public UserTimer timer;
    public PlayerDrink drink;
    public GameObject thing;
    public Animator crmlAnim, chocoAnim, strwAnim, vaiAnim; //Animators for pump
    public Sprite sCrml, sChoco, sStraw, sVai, sMilk, sIce;
    private GameObject copyThing;
    public Collider2D delete;
    //private bool onScreen;
    [SerializeField] float zPos;
    [SerializeField] AttachAndAnimate attach;
    public string objectType;


    private void Start()
    {
        drink = GameObject.Find("CostumerDrinkLogic").GetComponent<PlayerDrink>();
    }

    private void OnMouseDown()
    {
        

        // If there is no copy on screen, then make one
      if (DrinkManager.Instance.SpawnDrink(thing))
        {
            //onScreen = true;
            // Create object
            copyThing = Instantiate(thing, transform.position, transform.rotation);
            // Add the Draggable script to the cloned object
            Draggable draggable = copyThing.GetComponent<Draggable>();
            draggable.original = this;
            draggable.Attach(attach);
            draggable.Drink(drink);


            ChangeOnTouch change = copyThing.GetComponent<ChangeOnTouch>();

            change.original = this;
            change.Attach(attach);
            change.Drink(drink);
            attach.SetObjectType(objectType);
            attach.Change(change);

            ParticleCollision coll = copyThing.GetComponent<ParticleCollision>();
            coll.Drink(drink);

            timer.StartTimer();

            Debug.Log("New object created!");


            if (objectType == "Cup")
            {
                drink.AddIngredient("Hot");
            }
            else
            {
                drink.AddIngredient("Cold");
            }
            


        }
  
    
    }

    public void Destroyed()
    {
        //onScreen=false;
        DrinkManager.Instance.RemoveDrink();
        Debug.Log("Destroyed");
    }

  
    
}



  
