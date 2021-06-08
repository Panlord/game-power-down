// Created by Aaron Pan, based off of SpeedTutor's "OPENING a DOOR in UNITY with a RAYCAST" tutorial on YouTube.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator DoorAnimator;
    private AudioSource audio;
    public AudioClip open;
    public AudioClip close;
    private bool DoorOpen = false;

    private void Awake()
    {
        DoorAnimator = gameObject.GetComponent<Animator>();
    }

    private void Start()
    {

        audio = GetComponent<AudioSource>();
        
       
    }

    public void PlayAnimation()
    {
        if (!DoorOpen)
        {
            DoorAnimator.Play("DoorOpen", 0, 0.0f);
            DoorOpen = true;

            if (audio != null)
            {
                audio.clip = open;
                audio.Play();
            }

        }
        else
        {
            DoorAnimator.Play("DoorClose", 0, 0.0f);
            DoorOpen = false;

            if (audio != null)
            {
                audio.clip = close;
                audio.Play();
            }
        }
    }

    public void Close()
    {
        if (DoorOpen)
        {
            PlayAnimation();
        }
    }

    public bool IsOpen()
    {
        return this.DoorOpen;
    }
}