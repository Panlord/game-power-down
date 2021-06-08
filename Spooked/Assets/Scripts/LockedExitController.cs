// Created by Peter Lin.
// Adapted from Aaron Pan's DoorController.cs.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedExitController : MonoBehaviour
{
    private InterfaceController GUI;
    private KeyCode InteractKey = KeyCode.E;

    private void Awake()
    {
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
        this.GUI.PromptExit();
    }

    public void Interact()
    {
        // Check if book has been picked up.
        Debug.Log("Go pick up book first");
        // Locked door so this isn't openning.
        Debug.Log("This door is locked");
    }
}