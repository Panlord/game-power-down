using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    // followed this tutorial and implemented a couple extra functions: 
    // https://www.youtube.com/watch?v=qc7J0iei3BU

    public static TimerController timer;
    public Text timeCounter;
    private TimeSpan timePlaying;
    private bool timerGoing;
    private float elapsedTime;

    private void Awake()
    {
        timer = this;
    }

    private void Start()
    {
        timeCounter.text = "";
        timerGoing = false;
    }

    public void BeginTimer()
    {
        timerGoing = true;
        elapsedTime = 0f;
    
        StartCoroutine(UpdateTimer());
    }

    public void PauseTime()
    {
        timerGoing = false;
    }

    public void ContinueTime()
    {
        timerGoing = true;
        StartCoroutine(UpdateTimer());
    }

    public void ResetTimer()
    {
        timeCounter.text = "";
        timerGoing = false;
    }

    private IEnumerator UpdateTimer()
    {
        while(timerGoing)
        {
            elapsedTime +=Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = timePlayingStr;

            yield return null;
        }
    }

}