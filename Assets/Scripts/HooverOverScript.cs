using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HooverOverScript : MonoBehaviour
{
    //Bruh this script was way easy than i thought, reminder for me
    //Add clicking mechanic similar to the one I use for the cup and vasito
    // Probably will do by calling that script but we will see later ;)
    private SpriteRenderer rend;
    [SerializeField]private Sprite sprite1, sprite2;
    private bool onImage = false;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rend.sprite = sprite1;
    }

    private void OnMouseExit()
    {
        assignNew(sprite1);
    }

    private void OnMouseOver()
    {
        assignNew(sprite2);
    }

    
    public void assignNew(Sprite sprite)
    {
        rend.sprite = sprite;
    }
}
