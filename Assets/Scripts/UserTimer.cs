using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserTimer : MonoBehaviour
{
    private float startTime;
    private bool timerRunning = false;
    public float timerTime = 0;

    public void StartTimer()
    {
        startTime = Time.time; //start the time
        timerRunning = true;
    }

    public void StopTimer()
    {
        if (timerRunning)
        {
            timerTime = Time.time - startTime;
            timerRunning=false;
            Debug.Log("Time taken:" +  timerTime);

           
        }

    
    }

    public float returnTime()
    {
        return timerTime;
    }


}
