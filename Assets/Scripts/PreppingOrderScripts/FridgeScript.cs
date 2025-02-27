using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FridgeScript : MonoBehaviour
{
    [SerializeField] GameObject milk;
    [SerializeField] GameObject ice;

    private bool dragged;
    private float zPos = -2.5f;
    
    public Collider2D milkArea;
    public Collider2D iceArea;

    private GameObject draggedObject;
    private Vector2 dragOffset;
    private Vector2 ogPosition;

    void Start()
    {
  
        milk.SetActive(false);
        ice.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (dragged && draggedObject != null)
        {
            Vector2 mousePosition = GetMousePos();
            draggedObject.transform.position = new Vector3(mousePosition.x - dragOffset.x, mousePosition.y - dragOffset.y, zPos);
        }
        
    }

    private void OnMouseDown()
    {
        
        var mousePosition = GetMousePos();

        if (milkArea.OverlapPoint(mousePosition))
        {
            DragObject(milk);
        }
        else if (iceArea.OverlapPoint(mousePosition))
        {
            DragObject(ice);
            Debug.Log("Ice made");
        }
    }

    private void OnMouseUp()
    {
        if (draggedObject != null)
        {
            draggedObject.transform.position = ogPosition;
            draggedObject.SetActive(false);
            draggedObject = null;
            dragged = false;
        }

    }

    private void DragObject(GameObject obj)
    {
        draggedObject = obj;
        ogPosition = obj.transform.position;
        draggedObject.SetActive(true);
        dragOffset = GetMousePos() - (Vector2)draggedObject.transform.position;
        dragged = true;
    }
    Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

}
