// Created by Aaron Pan, based off of SpeedTutor's "OPENING a DOOR in UNITY with a RAYCAST" tutorial on YouTube.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoreRaycast : MonoBehaviour
{
    [SerializeField] private int RayLength = 5;
    [SerializeField] private LayerMask LayerMaskInteract;
    [SerializeField] private string ExcludeLayerName = null;
    private GameObject RayCastedObject;

    [SerializeField] private KeyCode LoreKey = KeyCode.E;

    [SerializeField] private Image Crosshair = null;
    private bool IsCrosshairActive;
    private bool DoOnce;

    private bool LoreObtained = false;

    private bool BookObtained = false;

    private const string InteractableTag = "CollectibleItem";

    public bool GotLore()
    {
        return this.LoreObtained;
    }

    public bool GotBook()
    {
        return this.BookObtained;
    }

    public void ResetLore()
    {
        this.LoreObtained = false;
    }

    public void ResetBook()
    {
        this.BookObtained = false;
    }

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
                    RayCastedObject = hit.collider.gameObject;
                    CrosshairChange(true);
                }
                IsCrosshairActive = true;
                DoOnce = true;
                if (Input.GetKeyDown(LoreKey))
                {
                    this.LoreObtained = true;
                    RayCastedObject.SetActive(false);
                }
            }
            else if (hit.collider.CompareTag("ObjectiveItem"))
            {
                if (!DoOnce)
                {
                RayCastedObject = hit.collider.gameObject;
                CrosshairChange(true);
                }
                IsCrosshairActive = true;
                DoOnce = true;
                if (Input.GetKeyDown(LoreKey))
                {
                    this.BookObtained = true;
                    RayCastedObject.SetActive(false);
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