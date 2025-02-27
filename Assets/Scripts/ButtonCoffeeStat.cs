using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCoffeeStat : MonoBehaviour
{
    [SerializeField] private UserTimer timer;
    [SerializeField] private ScenesManager scenes;
    [SerializeField] private BagManager bag;

    private void Start()
    {
        bag = GameObject.Find("BagManager").GetComponent<BagManager>();
    }
    public void goButton()
    {
        

        if (PlayerDrink.Instance.drinkMade.Count > 0)
        {
            Debug.Log("Next Scene");
            timer.StopTimer();
            scenes.BeforeScene();
            BagManager.Instance.ShowBag();

        }

    }

    
}
