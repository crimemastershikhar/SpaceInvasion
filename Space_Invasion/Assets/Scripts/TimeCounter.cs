using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    Text timeUI;
    float startTime;
    float ellapsedTime;
    bool startCounter;
    int minutes;
    int seconds;
    private void Start()
    {
        startCounter = false;
        timeUI = GetComponent<Text>(); //fet text UI component from this gameobeject
    }
    public void StartTimeCounter()
    {
        startTime = Time.time;
        startCounter = true;
    }
    public void StopTimeCounter()
    {
        startCounter = false;
    }
    private void Update()
    {
        if (startCounter)
        {
            ellapsedTime = Time.time - startTime;
            minutes = (int)ellapsedTime / 60;  // get the mins
            seconds = (int)ellapsedTime % 60;
            timeUI.text = string.Format("{0:00}:{1:00}", minutes, seconds); //update time counter UI text
        }
    }

}
