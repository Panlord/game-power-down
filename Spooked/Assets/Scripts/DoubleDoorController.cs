// Created by Aaron Pan, based off of SpeedTutor's "OPENING a DOOR in UNITY with a RAYCAST" tutorial on YouTube.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDoorController : MonoBehaviour
{
    private Animator DoubleDoorAnimator;
    private bool DoubleDoorOpen = false;

    private void Awake()
    {
        DoubleDoorAnimator = gameObject.GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        if (!DoubleDoorOpen)
        {
            DoubleDoorAnimator.Play("DoubleDoorOpen", 0, 0.0f);
            DoubleDoorOpen = true;
        }
        else
        {
            DoubleDoorAnimator.Play("DoubleDoorClose", 0, 0.0f);
            DoubleDoorOpen = false;
        }
    }

    public void Close()
    {
        if (DoubleDoorOpen)
        {
            PlayAnimation();
        }
    }

    public bool IsOpen()
    {
        return this.DoubleDoorOpen;
    }
}
