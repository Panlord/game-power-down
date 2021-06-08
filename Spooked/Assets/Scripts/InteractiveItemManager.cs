// Created by Peter Lin.
// Adapted from Aaron Pan's DoorRaycast.cs (legacy)

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractiveItemManager : MonoBehaviour
{
    [SerializeField] private int RayLength = 2;
    [SerializeField] private LayerMask LayerMaskInteract;
    [SerializeField] private string ExcludeLayerName = null;

    [SerializeField] private InterfaceController GUI;

    private const string TagDoor = "Door";
    private const string TagDoubleDoor = "DoubleDoor";
    private const string TagCollectibleItem = "CollectibleItem";
    private const string TagObjectiveItem = "ObjectiveItem";
    private const string TagLockedExitItem = "LockedExit";

    private void Update() {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(ExcludeLayerName) | LayerMaskInteract.value;

        // If the raycast hits an object with any of the valid tags, enable button prompt.
        if (Physics.Raycast(transform.position, fwd, out hit, RayLength, mask))
        {
            // Only show prompt if viewing a promptable object.
            switch (hit.collider.tag)
            {
                case TagDoor:
                case TagDoubleDoor:
                case TagCollectibleItem:
                case TagObjectiveItem:
                case TagLockedExitItem:
                    this.ProcessItem(hit);
                    break;
                default:
                    this.GUI.EndPrompt();
                    break;
            }
        }
        else
        // No interactive item in range, so disable button prompts.
        {
            this.GUI.EndPrompt();
        }
    }

    private void ProcessItem(RaycastHit hit)
    {
        var itemTag = hit.collider.tag;
        var rayCastedObject = hit.collider.gameObject;

        switch (itemTag)
        {
            case TagDoor:
                var door = rayCastedObject.GetComponent<DoorController>();
                door.Process();
                break;
            case TagDoubleDoor:
                var doubleDoor = rayCastedObject.GetComponent<DoubleDoorController>();
                doubleDoor.Process();
                break;
            case TagCollectibleItem:
                var collectibleItem = rayCastedObject.GetComponent<CollectibleItemController>();
                collectibleItem.Process();
                break;
            case TagObjectiveItem:
                var objectiveItem = rayCastedObject.GetComponent<ObjectiveItemController>();
                objectiveItem.Process();
                break;
            case TagLockedExitItem:
                var exitDoor = rayCastedObject.GetComponent<ExitDoorController>();
                exitDoor.Process();
                break;
            default:
                break;
        }
    }
}
