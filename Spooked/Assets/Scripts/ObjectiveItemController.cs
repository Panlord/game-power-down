// Created by Peter Lin.
// Adapted from Aaron Pan's DoorController.cs.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveItemController : MonoBehaviour
{
    private InterfaceController GUI;
    private Inventory PlayerInventory;
    private KeyCode InteractKey = KeyCode.E;
    // Add Inventory class.

    private void Awake()
    {
        this.GUI = GameObject.Find("User Interface").GetComponent<InterfaceController>();
        this.PlayerInventory = GameObject.Find("Inventory").GetComponent<Inventory>();
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
        this.GUI.PromptCollect();
    }

    public void Interact()
    {
        this.GUI.EndPrompt();
        Debug.Log("Picked up objective");
        // Initiate monster hunt.
        this.PlayerInventory.CollectBook();
        this.gameObject.SetActive(false);
    }
}