// Created by Aaron Pan, based off of SpeedTutor's "OPENING a DOOR in UNITY with a RAYCAST" tutorial on YouTube.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorRaycast : MonoBehaviour
{
    [SerializeField] private int RayLength = 5;
    [SerializeField] private LayerMask LayerMaskInteract;
    [SerializeField] private string ExcludeLayerName = null;

    private DoorController RayCastedObject;

    [SerializeField] private KeyCode OpenDoorKey = KeyCode.E;

    [SerializeField] private Image Crosshair = null;
    private bool IsCrosshairActive;
    private bool DoOnce;

    private const string InteractableTag = "Door";

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(ExcludeLayerName) | LayerMaskInteract.value;

        // If the raycast hits an object (the door) with the InteractiveObject tag, open the door.
        if (Physics.Raycast(transform.position, fwd, out hit, RayLength, mask))
        {
            if (hit.collider.CompareTag(InteractableTag))
            {
                if (!DoOnce)
                {
                    RayCastedObject = hit.collider.gameObject.GetComponent<DoorController>();
                    CrosshairChange(true);
                }
                IsCrosshairActive = true;
                DoOnce = true;
                if (Input.GetKeyDown(OpenDoorKey))
                {
                    RayCastedObject.PlayAnimation();
                }
            }
        }
        else
        {
            if (IsCrosshairActive)
            {
                CrosshairChange(false);
                DoOnce = false;
            }
        }
    }

    // Function to change the color of the crosshair.
    void CrosshairChange(bool on)
    {
        if (on && DoOnce)
        {
            Crosshair.color = Color.red;
        }
        else
        {
            Crosshair.color = Color.white;
            IsCrosshairActive = false;
        }
    }
}