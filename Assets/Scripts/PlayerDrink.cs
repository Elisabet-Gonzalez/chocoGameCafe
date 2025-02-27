using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrink : MonoBehaviour
{

    public static PlayerDrink Instance { get; private set; }

    public List<string> drinkMade = new List<string>(); //The list that contains what the user is doing with the drink
    public ScenesManager scenes;
    public TextToScreen text;
    public UserTimer timer;
    public int rating = 0;
    public float price = 0;
    public int avgRating = 0;
    public float totalPrice = 0;
    private int countCos = 0;

    private void Start()
    {
        timer = GameObject.Find("Timer").GetComponent<UserTimer>();
        
        scenes = GameObject.Find("SceneManager").GetComponent<ScenesManager>();
    }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void AddIngredient(string name)
    {
        drinkMade.Add(name);
        Debug.Log("Current drink: " + string.Join(", ", drinkMade));
    }

    public void replaceIngredient(string name, int index)
    {
        drinkMade.RemoveAt(index);
        drinkMade.Add(name);
        Debug.Log("Current drink: " + string.Join(", ", drinkMade));
    }

    

    public void SubmitDrink()
    {
        text = GameObject.Find("TextToScreen").GetComponent<TextToScreen>();
        countCos++;
        rating = 0;
        price = 0;


        rating = CalculateRating(drinkMade, OrderManager.Instance.currentOrder);
        price = CalculatePrice(drinkMade, OrderManager.Instance.currentOrder);

        totalPrice += price;
        avgRating = rating / countCos;

        Debug.Log("Your rating is:" + rating + " and your pay is: " + price);

        ClearDrink();
        OrderManager.Instance.ClearOrder();

        BagManager.Instance.HideBag();

        text.UpdateTheText();
        
        FindObjectOfType<CostumerGenerator>().GenerateCostumer();

    }

    private float CalculatePrice(List<string> playerOrder, List<string> requestedOrder)
    {
        float poinT = (float)TimePoints();
        float poinTop = (float)ToppingScores(playerOrder, requestedOrder);

        return 4f + (poinTop * 0.5f) + (poinT * 0.75f);

    }
    private int CalculateRating(List<string> playerOrder, List<string> requestedOrder)
    {
        int pointT = TimePoints();
        int pointTop = ToppingScores(playerOrder, requestedOrder);

        return (pointT + pointTop) / 2;
    }


    private int ToppingScores(List<string> playerOrder, List<string> requestedOrder)
    {
        int toppingScore = 1;

        for (int i = 0; i < playerOrder.Count; i++)
        {
            if (i < requestedOrder.Count && playerOrder[i] == requestedOrder[i])
            {
                toppingScore++;
            }
        }
        return toppingScore;
    }




    private int TimePoints()
    {
        int time = (int)timer.returnTime();
        int timePoint = 0;

        if (time <= 17)
        {
            timePoint += 5;
        }
        else if (time <= 25 && time > 17)
        {
            timePoint += 4;
        }
        else if (time <= 35 && time > 25)
        {
            timePoint += 3;
        }
        else if (time <= 50 && time > 35)
        {
            timePoint += 2;
        }
        else if (time > 50)
        {
            timePoint += 1;
        }

        return timePoint;
    }


    public void ClearDrink()
    {

        drinkMade.Clear();
    }


    public void GoToOrderScene()
    {
        Debug.Log("Next Scene");


        if (drinkMade.Count > 0)
        {
            Debug.Log("Next Scene");
            timer.StopTimer();
            scenes.BeforeScene();
            BagManager.Instance.ShowBag();
            
        }


    }
}