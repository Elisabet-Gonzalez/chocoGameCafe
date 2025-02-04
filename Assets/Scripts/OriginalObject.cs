using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OriginalObject : MonoBehaviour
{
    //Second try of the code
    [SerializeField] GameObject thing;
    private GameObject copyThing;
    private bool onScreen = false;
    private Vector2 ogPosition;
    [SerializeField] float zPos;

    private void OnMouseDown()
    {
        if (!onScreen)
        {
            onScreen = true;

            copyThing = Instantiate(thing, transform.position, transform.rotation);
        }

        copyThing.AddComponent<Draggable>();
        Debug.Log("New Object!!1");
    }
}
