// Created by Aaron Pan, based off of SpeedTutor's "OPENING a DOOR in UNITY with a RAYCAST" tutorial on YouTube.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDoorController : MonoBehaviour
{
    private Animator DoubleDoorAnimator;
    private bool DoubleDoorOpen = false;
    private AudioSource Audio;
    [SerializeField]
    public AudioClip open;
    [SerializeField]
    private AudioClip close;

    private void Awake()
    {
        DoubleDoorAnimator = gameObject.GetComponent<Animator>();
        Audio = GetComponent<AudioSource>();
    }

    public void PlayAnimation()
    {
        if (!DoubleDoorOpen)
        {
            DoubleDoorAnimator.Play("DoubleDoorOpen", 0, 0.0f);
            DoubleDoorOpen = true;
            if (Audio != null)
            {
                Audio.clip = open;
                Audio.Play();
            }
        }
        else
        {
            DoubleDoorAnimator.Play("DoubleDoorClose", 0, 0.0f);
            DoubleDoorOpen = false;
            if (Audio != null)
            {
                Audio.clip = close;
                Audio.Play();
            }
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
