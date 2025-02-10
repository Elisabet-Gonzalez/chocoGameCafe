using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Device;

public class OriginalObject : MonoBehaviour
{
    Draggable drag;
    [SerializeField] GameObject thing; 
    private GameObject copyThing;
    public Collider2D delete;
    private bool onScreen;
    [SerializeField] float zPos;


    private void OnMouseDown()
    {
        // If there is no copy on screen, then make one
        if (!onScreen)
        {
            onScreen = true;
            // Create object
            copyThing = Instantiate(thing, transform.position, transform.rotation);
            // Add the Draggable script to the cloned object
            Draggable draggable = copyThing.GetComponent<Draggable>();
            draggable.original = this;
            Debug.Log("New object created!");
            

        }
  
    
    }

    public void Destroyed()
    {
        onScreen=false;
        Debug.Log("Destroyed");
    }

}



  
