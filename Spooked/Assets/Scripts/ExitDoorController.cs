// Created by Peter Lin.
// Adapted from Aaron Pan's DoorController.cs.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoorController : MonoBehaviour
{
    private InterfaceController GUI;
    private KeyCode InteractKey = KeyCode.E;
    private bool TriedExit;

    private void Awake()
    {
        this.GUI = GameObject.Find("User Interface").GetComponent<InterfaceController>();
        this.TriedExit = false;
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
        this.TriedExit = true;
        this.GUI.EndPrompt();
    }

    public int ExitCheck(bool hasBook)
    {
        if (this.TriedExit)
        {
            this.TriedExit = false;
            {
                if (!hasBook)
                {
                    return 0;
                }
                else if (this.gameObject.transform.parent.tag != "ExitDoor")
                {
                    return 1;
                }
                else if (this.gameObject.transform.parent.tag == "ExitDoor")
                {
                    return 2;
                }
                else
                {
                    return -1;
                }
            }
        }
        else
        {
            return -1;
        }
    }
}