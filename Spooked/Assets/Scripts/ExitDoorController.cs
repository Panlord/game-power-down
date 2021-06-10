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
        if (this.GUI.IsExitOpen())
        {
            if (this.gameObject.transform.parent.tag == "ExitDoor")
            {
                this.GUI.PromptExit();
            }
            else
            {
                this.GUI.PromptLocked();
            }
        }
        else
        {
            this.GUI.PromptBook();
        }
    }

    public void Interact()
    {
        this.TriedExit = true;
        this.GUI.EndPrompt();
    }

    public int ExitCheck()
    {
        if (this.TriedExit)
        {
            this.TriedExit = false;
            {
                if (!this.GUI.IsExitOpen())
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