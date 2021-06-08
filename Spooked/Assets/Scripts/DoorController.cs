// Created by Aaron Pan, based off of SpeedTutor's "OPENING a DOOR in UNITY with a RAYCAST" tutorial on YouTube.
// Adapted by Peter Lin.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator DoorAnimator;
    private AudioSource Audio;
    public AudioClip open;
    public AudioClip close;
    private InterfaceController GUI;
    private KeyCode InteractKey = KeyCode.E;
    private bool DoorOpen = false;

    private void Awake()
    {
        this.DoorAnimator = gameObject.GetComponent<Animator>();
        this.GUI = GameObject.Find("User Interface").GetComponent<InterfaceController>();
    }

    public void Process()
    {
        this.Prompt();

        if (Input.GetKeyDown(InteractKey))
        {
            this.Interact();
        }
    }

    private void Prompt()
    {
        if (this.DoorOpen)
        {
            this.GUI.PromptDoorClose();
        }
        else
        {
            this.GUI.PromptDoorOpen();
        }
    }

    private void Start()
    {

        Audio = GetComponent<AudioSource>();
        
       
    }

    private void Interact()
    {
        if (!this.DoorOpen)
        {
            DoorAnimator.Play("DoorOpen", 0, 0.0f);
            DoorOpen = true;
            this.GUI.PromptDoorClose();
            if (Audio != null)
            {
                Audio.clip = open;
                Audio.Play();
            }

        }
        else
        {
            DoorAnimator.Play("DoorClose", 0, 0.0f);
            DoorOpen = false;
            this.PromptDoorOpen();
            if (Audio != null)
            {
                Audio.clip = close;
                Audio.Play();
            }
        }
    }

    public void Close()
    {
        if (DoorOpen)
        {
            Interact();
        }
    }

    public bool IsOpen()
    {
        return this.DoorOpen;
    }
}
