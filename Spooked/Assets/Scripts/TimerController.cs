using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerController : MonoBehaviour
{
    // Followed this tutorial and implemented a couple extra functions: 
    // https://www.youtube.com/watch?v=qc7J0iei3BU.

    private TextMeshProUGUI TimeCounter;
    private TimeSpan TimePlaying;
    private bool TimerGoing;
    private float ElapsedTime;

    private void Awake()
    {
        this.TimeCounter = this.gameObject.GetComponent<TextMeshProUGUI>();
        this.TimeCounter.text = "";
        this.TimerGoing = false;
    }

    public void BeginTimer()
    {
        this.TimerGoing = true;
        this.ElapsedTime = 0f;

    }

    public void PauseTime()
    {
        this.TimerGoing = false;
    }

    public void ContinueTime()
    {
        this.TimerGoing = true;
    }

    public void ResetTimer()
    {
        this.TimeCounter.text = "";
        this.TimerGoing = false;
    }

    void Update()
    {
        if (this.TimerGoing)
        {
            this.ElapsedTime += Time.deltaTime;
            this.TimePlaying = TimeSpan.FromSeconds(this.ElapsedTime);
            var timePlayingStr = this.TimePlaying.ToString("mm':'ss'.'ff");
            this.TimeCounter.text = timePlayingStr;
        }
    }
}