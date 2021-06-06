// Created by Aaron Pan, based off of SpeedTutor's "OPENING a DOOR in UNITY with a RAYCAST" tutorial on YouTube.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator DoorAnimator;
    private bool DoorOpen = false;

    private void Awake()
    {
        DoorAnimator = gameObject.GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        if (!DoorOpen)
        {
            DoorAnimator.Play("DoorOpen", 0, 0.0f);
            DoorOpen = true;
        }
        else
        {
            DoorAnimator.Play("DoorClose", 0, 0.0f);
            DoorOpen = false;
        }
    }

    public void Close()
    {
        if (DoorOpen)
        {
            PlayAnimation();
        }
    }
}