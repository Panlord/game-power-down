// Created by Aaron Pan, based off of SpeedTutor's "OPENING a DOOR in UNITY with a RAYCAST" tutorial on YouTube.
// Adapted by Peter Lin.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDoorController : MonoBehaviour
{
    private Animator DoubleDoorAnimator;
    private InterfaceController GUI;
    private AudioSource Audio;
    [SerializeField] public AudioClip OpenSound;
    [SerializeField] private AudioClip CloseSound;
    private bool DoubleDoorOpen = false;

    private void Awake()
    {
        this.DoubleDoorAnimator = gameObject.GetComponent<Animator>();
        this.GUI = GameObject.Find("User Interface").GetComponent<InterfaceController>();
        this.Audio = this.gameObject.GetComponent<AudioSource>();
    }

    public void Process()
    {
        this.Prompt();

        if (Input.GetButtonDown("Use"))
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
            this.DoubleDoorAnimator.Play("DoubleDoorOpen", 0, 0.0f);
            this.DoubleDoorOpen = true;
            this.GUI.PromptDoorClose();

            if (this.Audio != null)
            {
                this.Audio.clip = this.OpenSound;
                this.Audio.Play();
            }
        }
        else
        {
            this.DoubleDoorAnimator.Play("DoubleDoorClose", 0, 0.0f);
            this.DoubleDoorOpen = false;
            this.GUI.PromptDoorOpen();

            if (this.Audio != null)
            {
                this.Audio.clip = this.CloseSound;
                this.Audio.Play();
            }
        }
    }

    public void Close()
    {
        if (this.DoubleDoorOpen)
        {
            this.Interact();
        }
    }

    public bool IsOpen()
    {
        return this.DoubleDoorOpen;
    }
}
