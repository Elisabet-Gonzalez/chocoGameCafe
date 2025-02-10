using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public OriginalObject original;
    private bool dragged = false;
    private Vector2 dragOffset;
    [SerializeField] float zPos = -2f;
    private Collision2D coll;


    private void Start()
    {
        original = FindObjectOfType<OriginalObject>();
        

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
            Destroy(gameObject);
            dragged = false;
            
        }
    }

    public bool returnDragged()
    {
        return dragged;
    }
    Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    


}
