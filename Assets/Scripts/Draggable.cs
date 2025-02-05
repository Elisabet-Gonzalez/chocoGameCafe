using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private bool dragged = false;
    private Vector2 dragOffset;
    [SerializeField] float zPos = -2f;

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
        if (!dragged)
        {
            return;
        }

        var mousePosition = GetMousePos();
        transform.position = new Vector3(mousePosition.x - dragOffset.x, mousePosition.y - dragOffset.y, zPos);
    }

    Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
