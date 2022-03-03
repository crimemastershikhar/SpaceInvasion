using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    [SerializeField] private Text timeUI;
    [SerializeField] private float startTime;
    [SerializeField] private float ellapsedTime;
    private bool startCounter;
    private int minutes;
    private int seconds;
    
    private void Start()
    {
        startCounter = false;
        timeUI = GetComponent<Text>(); 
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
            minutes = (int)ellapsedTime / 60;  
            seconds = (int)ellapsedTime % 60;
            timeUI.text = string.Format("{0:00}:{1:00}", minutes, seconds); 
        }
    }

}
