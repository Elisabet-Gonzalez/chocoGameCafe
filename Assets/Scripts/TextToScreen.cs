using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextToScreen : MonoBehaviour
{

   

    [SerializeField] private TextMeshProUGUI textMoney;
    [SerializeField] private TextMeshProUGUI textScore;
    [SerializeField] private TextMeshProUGUI textDay;
    private float money = 0;
    private int score = 0;
   // private int day = 0;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void UpdateTheText()
    {
        money = PlayerDrink.Instance.totalPrice;
        textMoney.text = money.ToString();

        score = PlayerDrink.Instance.avgRating;
        textScore.text = score.ToString();

        Debug.Log("I ran");
        

    }
}
