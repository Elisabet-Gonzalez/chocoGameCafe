using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public OriginalObject original;
    private bool dragged = false;
    private Vector2 dragOffset;
    [SerializeField] float zPos = -2f;
    private Collision2D coll;
    public AttachAndAnimate attach;
    private ChangeOnTouch change;
   [SerializeField] private PlayerDrink drink;
    [SerializeField] ParticleCollision particle;


    private void Start()
    {
        change = GetComponent<ChangeOnTouch>();
        particle = GetComponent<ParticleCollision>();
    }
    public void Attach(AttachAndAnimate atAndAnim)
    {
        attach = atAndAnim;
    }

    public void Drink(PlayerDrink d)
    {
        drink = d;
    }

    private void OnMouseDown()
    {
        dragged = true;
        dragOffset = GetMousePos() - (Vector2)transform.position;
    }

    private void OnMouseUp()
    {
        dragged = false;
    }

    private void Update()
    {
        // If not being dragged then do not run the rest of the code
        if (!dragged)
        {
            return;
        }

        // Obtain the mouse current position, and then use that for the object
        var mousePosition = GetMousePos();
        // Get the copy position and assign it a new position 
        transform.position = new Vector3(mousePosition.x - dragOffset.x, mousePosition.y - dragOffset.y, zPos);
       
    }

    private void OnMouseOver()
    {
        var mousePos = GetMousePos();
        if (original.delete.OverlapPoint(mousePos))
        {

            Debug.Log("Ew trash");
            original.Destroyed();
            DrinkManager.Instance.RemoveDrink();
            Destroy(gameObject);
            dragged = false;
            attach.coffeeOnObject = false;
            change.milkReady = false;
            drink.ClearDrink();
            particle.counter = 0;
        }
    }

    private void OnDestroy()
    {
        if(DrinkManager.Instance != null)
        {
            
            DrinkManager.Instance.RemoveDrink();
        }
    }


    Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    


}
