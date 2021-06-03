// Created by Peter Lin.
// Adapted from Aaron Pan's DoorRaycast.cs (legacy)

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractiveItemManager: MonoBehaviour
{
    [SerializeField] private int RayLength = 2;
    [SerializeField] private LayerMask LayerMaskInteract;
    [SerializeField] private string ExcludeLayerName = null;
    [SerializeField] private KeyCode InteractKey = KeyCode.E;

    private InterfaceController GUI;
    private bool ValidItemInView;
    private DoorController Door;
    private DoubleDoorController DoubleDoor;
    // private CollectibleItemController CollectibleItem;
    // private ObjectiveItemController ObjectiveItem;

    private const string TagDoor = "Door";
    private const string TagDoubleDoor = "DoubleDoor";
    private const string TagCollectibleItem = "CollectibleItem";
    private const string TagObjectiveItem = "ObjectiveItem";

    private void Awake() {
        this.GUI = GameObject.Find("User Interface").GetComponent<InterfaceController>();
        this.ValidItemInView = false;
    }

    private void Update() {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(ExcludeLayerName) | LayerMaskInteract.value;

        // If the raycast hits an object with any of the valid tags, enable button prompt.
        if (Physics.Raycast(transform.position, fwd, out hit, RayLength, mask))
        {
            switch (hit.collider.tag)
            {
                case TagDoor:
                case TagDoubleDoor:
                case TagCollectibleItem:
                case TagObjectiveItem:
                    this.ProcessItem(hit);
                    break;
                default:
                    this.ValidItemInView = false;
                    this.GUI.EndPrompt();
                    break;
            }
        }
        else
        // No interactive item in range, so disable button prompts.
        {
            this.ValidItemInView = false;
            this.GUI.EndPrompt();
        }
    }

    private void ProcessItem(RaycastHit hit)
    {
        var itemTag = hit.collider.tag;

        switch (itemTag)
        {
            case TagDoor:
                ProcessDoor(hit);
                break;
            case TagDoubleDoor:
                ProcessDoubleDoor(hit);
                break;
            case TagCollectibleItem:
                ProcessCollectibleItem(hit);
                break;
            case TagObjectiveItem:
                ProcessObjectiveItem(hit);
                break;
            default:
                break;
        }
    }

    private void ProcessDoor(RaycastHit hit)
    {
        if (!this.ValidItemInView) {
            this.ValidItemInView = true;
            this.Door = hit.collider.gameObject.GetComponent<DoorController>();
            this.Door.Prompt();
        }
        
        if (Input.GetKeyDown(InteractKey))
        {
            this.Door.Interact();
        }
    }

    private void ProcessDoubleDoor(RaycastHit hit)
    {
        if (!this.ValidItemInView) {
            this.ValidItemInView = true;
            this.DoubleDoor = hit.collider.gameObject.GetComponent<DoubleDoorController>();
            this.DoubleDoor.Prompt();
        }

        if (Input.GetKeyDown(InteractKey))
        {
            this.DoubleDoor.Interact();
        }
    }

    private void ProcessCollectibleItem(RaycastHit hit)
    {
        if (!this.ValidItemInView) {
            this.ValidItemInView = true;
            // this.CollectibleItem = hit.collider.gameObject.GetComponent<CollectibleItemController>();
            this.GUI.PromptInspect();
            // this.CollectibleItem.Prompt();
        }

        if (Input.GetKeyDown(InteractKey))
        {
            Debug.Log("picked up collectible");
            // this.CollectibleItem.Interact();
        }
    }

    private void ProcessObjectiveItem(RaycastHit hit)
    {
        if (!this.ValidItemInView) {
            this.ValidItemInView = true;
            // this.ObjectiveeItem = hit.collider.gameObject.GetComponent<ObjectiveItemController>();
            this.GUI.PromptInspect();
            // this.ObjectiveeItem.Prompt();
        }

        if (Input.GetKeyDown(InteractKey))
        {
            Debug.Log("picked up objective");
            // this.ObjectiveeItem.Interact();
        }
    }
}
