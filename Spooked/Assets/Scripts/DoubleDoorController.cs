// Created by Aaron Pan, based off of SpeedTutor's "OPENING a DOOR in UNITY with a RAYCAST" tutorial on YouTube.
// Adapted by Peter Lin.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDoorController : MonoBehaviour
{
    private Animator DoubleDoorAnimator;
    private InterfaceController GUI;
    private KeyCode InteractKey = KeyCode.E;
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

    public void Prompt()
    {
        if (this.DoubleDoorOpen)
        {
            this.GUI.PromptDoorClose();
        }
        else
        {
            this.GUI.PromptDoorOpen();
        }
    }

    public void Interact()
    {
        if (!this.DoubleDoorOpen)
        {
            DoubleDoorAnimator.Play("DoubleDoorOpen", 0, 0.0f);
            DoubleDoorOpen = true;
            this.GUI.PromptDoorClose();
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
            this.GUI.PromptDoorOpen();
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
