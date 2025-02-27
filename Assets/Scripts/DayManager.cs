

using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    public static DayManager Instance { get; private set; }

    [SerializeField] private CostumerGenerator orderAndCos;
    private int currentDay = 0; //the day duh
    private int currentDayIndex = 0;
    private string[] timeSegments = { "Morning", "Early Afternoon", "Late Afternoon", "Night" };

    private int ordersCompleted = 0;

    private int money;

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

    private void Start()
    {
        orderAndCos= GameObject.Find("CostumerLogic").GetComponent<CostumerGenerator>();

        StartNewDay();
    }

    public void StartNewDay()
    {
        currentDay++;
        currentDayIndex = 0; //start at the morning
        GenerateOrders();


    }

    private void GenerateOrders()
    {
        if (ordersCompleted < timeSegments.Length)
        {
            orderAndCos.GenerateCostumer();
        }
        else
        {
            EndDay();
        }


    }

    public void CompleteOrder()
    {
        ordersCompleted++;
        orderAndCos.Bye();
    }


    private void EndDay()
    {
        currentDay++;
        StartNewDay();
    }








}
