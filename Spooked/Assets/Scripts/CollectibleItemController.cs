// Created by Peter Lin.
// Adapted from Aaron Pan's DoorController.cs.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItemController : MonoBehaviour
{
    private InterfaceController GUI;
    private Inventory PlayerInventory;

    // Add Inventory class.

    private void Awake()
    {
        this.GUI = GameObject.Find("User Interface").GetComponent<InterfaceController>();
        this.PlayerInventory = GameObject.Find("Inventory").GetComponent<Inventory>();
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
        this.GUI.PromptCollect();
    }

    public void Interact()
    {
        this.GUI.EndPrompt();
        Debug.Log("Picked up collectible");
        // Add to inventory system.
        this.PlayerInventory.CollectItem();
        this.gameObject.SetActive(false);
    }
}
