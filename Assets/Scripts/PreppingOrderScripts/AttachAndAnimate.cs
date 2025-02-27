using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class AttachAndAnimate : MonoBehaviour
{
    
    DragScript drag;
    ChangeOnTouch change;
   // [SerializeField] private Transform targetArea;
    private Animator anim;
    [SerializeField] private Transform targetArea;
    [SerializeField]  private SpriteRenderer tuCola;
    [SerializeField] private Sprite cupCoffee, vasoCoffee;
    private string objectType;
    private IEnumerator Coroutine;
    private SpriteRenderer rend;
    private bool coffeGroundP = false;
   
    

    public bool coffeeOnObject = false;


    public void Change(ChangeOnTouch touch)
    {
        change = touch;
    }

    private void Start()
    {
         
        anim = GetComponent<Animator>();
        drag = GetComponent<DragScript>();
        
       
    }
    
    public void SetObjectType(string type)
    {

    objectType = type;
    }
   
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "CoffeeGrounds" && anim != null)
        {

            BeginAnim();


        }
        else if (collision.gameObject.name == "CoffeeMachine" && coffeGroundP ==true && change.OnMachine())
        {
            rend = change.ReturnSprite();
            Pour();
            Debug.Log("Kms");
           
        }


       
    }

    void Pour()
    {
        Debug.Log("Hello brou");
        if (anim != null)
        {
            Coroutine = WaitandPour();
            StartCoroutine(Coroutine);
        }

    }
    
   

    void BeginAnim()
    {
        
        

        if(anim != null)
        {
            anim.SetTrigger("Animate");
            
        }

        Coroutine = WaitAndAnim();
        StartCoroutine(Coroutine);
        
    }

    private IEnumerator WaitAndAnim()
    {

        

        anim.ResetTrigger("Animate");

        anim.SetTrigger("goFull");

        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);

        
       
        coffeGroundP = true;
    }

    private IEnumerator WaitandPour()
    {
        
        anim.ResetTrigger("goFull");

        

        anim.SetTrigger("pour");

        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);

        anim.ResetTrigger("pour");

        anim.SetTrigger("goBack");

        if (objectType == "Cup")
        {
            rend.sprite = cupCoffee;
        } 
        else if(objectType == "Vaso")
        {
            rend.sprite = vasoCoffee;
        }


        coffeGroundP = false;
        coffeeOnObject = true;
        

    }

    public bool checkCoffee()
    {
        return coffeeOnObject;
    }

}
