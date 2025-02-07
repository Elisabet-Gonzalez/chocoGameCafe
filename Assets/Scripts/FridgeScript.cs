using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeScript : MonoBehaviour
{
    HooverOverScript hov;
    [SerializeField] GameObject milk;
    [SerializeField] GameObject ice;
    private SpriteRenderer rend;
    private Sprite sprite1;
    private Sprite sprite2;
    private bool onScreen = false;
    private bool dragged = false;
    private Vector2 dragOffset;
    private Vector2 ogPosition;

    private void Awake()
    {
        ogPosition = transform.position;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnMouseDown()
    {
       
    }

    private void OnMouseOver()
    {
        hov.assignNew(sprite1);
    }
    private void OnMouseExit()
    {
        hov.assignNew(sprite2);
    }
}
