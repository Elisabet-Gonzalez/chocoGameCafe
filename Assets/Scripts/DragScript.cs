using System.Collections;
using System.Collections.Generic;
using UnityEngine;
   
public class DragScript : MonoBehaviour
{
    private bool onScreen;
    private Quaternion ogRotation;
    [SerializeField] private Vector3 newRotation;
    private Vector2 ogPosition;
    private bool dragged = false;
    private Vector2 dragOffset;
    [SerializeField] float zPos;

    private void Awake()
    { 
        //get em og postions heuheheu
        ogPosition = transform.position;
        ogRotation = transform.rotation;
    }


    // Update is called once per frame
    void Update()
    {
        // If not being dragged then do not run the rest of code
        if (!dragged)
        {
        return; 
        }
        //Obtain the mouse current position, and then use that for the object
        var mousePosition = GetMousePos();
        //Get the copy position and asign it a new position 
        transform.position = new Vector3(mousePosition.x - dragOffset.x, mousePosition.y - dragOffset.y, zPos);

    }
    private void OnMouseDown()
    {
        dragged = true;
        //YK move it
        dragOffset = GetMousePos() - (Vector2)transform.position;
        /*Euler as in the degrees that our object has rotated on the z axis, so I would like to guess that Quaternion.Euler tells our computer 
         * "Hey bff convert the z rotatiion of the Vector3 newRotation into Euler" so the computer gets it */
        transform.rotation = Quaternion.Euler(newRotation);
    }

      private void OnMouseUp()
    {
        //go back from where u came from!!! (literally)
       transform.position = ogPosition;
       transform.rotation = ogRotation;
        dragged = false;
    }

     public Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

}
