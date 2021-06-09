// Created by Aaron Pan, based off of SpeedTutor's "OPENING a DOOR in UNITY with a RAYCAST" tutorial on YouTube.
// Adapted by Peter Lin.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator DoorAnimator;
    private InterfaceController GUI;
    private AudioSource Audio;
    [SerializeField] public AudioClip OpenSound;
    [SerializeField] public AudioClip CloseSound;
    private bool DoorOpen = false;

    private void Awake()
    {
        this.DoorAnimator = gameObject.GetComponent<Animator>();
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

    private void Interact()
    {
        if (!this.DoorOpen)
        {
            this.DoorAnimator.Play("DoorOpen", 0, 0.0f);
            this.DoorOpen = true;
            this.GUI.PromptDoorClose();

            if (this.Audio != null)
            {
                this.Audio.clip = this.OpenSound;
                this.Audio.Play();
            }
        }
        else
        {
            this.DoorAnimator.Play("DoorClose", 0, 0.0f);
            this.DoorOpen = false;
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
        if (this.DoorOpen)
        {
            this.Interact();
        }
    }

    public bool IsOpen()
    {
        return this.DoorOpen;
    }
}
