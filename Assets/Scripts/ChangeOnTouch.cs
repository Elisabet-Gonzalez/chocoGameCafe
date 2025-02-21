using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class ChangeOnTouch : MonoBehaviour
{
    public OriginalObject original;
    private AttachAndAnimate attach;

    private Animator anim, anim2, anim3, anim4;
    private SpriteRenderer rend;
   
   
    private IEnumerator coroutine;

    private bool onCoffeeMachine = false;

    public bool milkReady = false;
    

    public void Attach(AttachAndAnimate atAndAnim)
    {
        attach = atAndAnim;
    }

    // Start is called before the first frame update
    void Start()
    {
        rend =  GetComponent<SpriteRenderer>();
    
        anim = original.crmlAnim;
        anim2 = original.chocoAnim;
        anim3 = original.strwAnim;
        anim4 = original.vaiAnim;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        //Does run past anim not null
        if (collision.gameObject.name == "paddleIce" && original.objectType == "Vaso")
        {
            rend.sprite = original.sIce;
        }


        if (attach.checkCoffee() == true)
        {

            
            if (collision.gameObject.name == "Milk")
            {
                rend.sprite = original.sMilk;
                milkReady = true;
            }
        }

        if(milkReady == true)
        {
            if (collision.gameObject.name == "CrmlSyrupArea" && anim != null)
            {
                coroutine = SyrupAnim(original.sCrml, anim);
                StartCoroutine(coroutine);

            }
            else if (collision.gameObject.name == "ChocoSyrupArea" && anim2 != null)
            {
                coroutine = SyrupAnim(original.sChoco, anim2);
                StartCoroutine(coroutine);
            }
            else if (collision.gameObject.name == "StrawSyrupArea" && anim3 != null)
            {
                coroutine = SyrupAnim(original.sStraw, anim3);
                StartCoroutine(coroutine);
            }
            else if (collision.gameObject.name == "VaiSyrupArea" && anim4 != null)
            {
                coroutine = SyrupAnim(original.sVai, anim4);
                StartCoroutine(coroutine);
            }
        } 


            


             if(collision.gameObject.name == "CupPlace")
            {
            
            onCoffeeMachine = true;
            

            }
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name == "CrmlSyrupArea" && anim != null && milkReady)
        {
            anim.ResetTrigger("WhenCollide");
            Debug.Log("Reset");
        }
        if(collision.gameObject.name == "CupPlace")
        {
            onCoffeeMachine = false;
            
        }

    }

   private IEnumerator SyrupAnim(Sprite spr, Animator anim)
    {
        anim.SetTrigger("WhenCollide");

        Debug.Log("Syrup going in!");

        yield return new WaitForSeconds(0.5f);

        rend.sprite = spr;
    }

   public bool OnMachine()
    {
        return onCoffeeMachine;

        
    }
   
    public SpriteRenderer ReturnSprite()
    {
        return rend;
    }

}