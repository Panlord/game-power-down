// Created by Peter Lin.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InterfaceController : MonoBehaviour
{
    [SerializeField] private GameObject Crosshair;
    [SerializeField] private InventoryMenuController InventoryMenu;
    [SerializeField] private GameObject Prompt;
    private bool PromptOpen;
    private bool CanExit;

    private void Awake()
    {
        this.PromptOpen = true;
        this.EndPrompt(); 
        this.CanExit = false;
    }

    private void BeginPrompt()
    {
        if (!this.PromptOpen)
        {
            this.PromptOpen = true;
            this.Crosshair.GetComponent<Image>().color = Color.red;
            this.Prompt.SetActive(true);
        } 
    }

    public void EndPrompt()
    {
        if (this.PromptOpen)
        {
            this.PromptOpen = false;
            this.Crosshair.GetComponent<Image>().color = Color.white;
            this.Prompt.SetActive(false);
        }
    }

    public void PromptDoorOpen()
    {
        this.BeginPrompt();
        this.Prompt.GetComponent<TextMeshProUGUI>().text = "[E] OPEN";
    }

    public void PromptDoorClose()
    {
        this.BeginPrompt();
        this.Prompt.GetComponent<TextMeshProUGUI>().text = "[E] CLOSE";
    }

    public void PromptCollect()
    {
        this.BeginPrompt();
        this.Prompt.GetComponent<TextMeshProUGUI>().text = "[E] COLLECT";
    }

    public void PromptBook()
    {
        this.BeginPrompt();
        this.Prompt.GetComponent<TextMeshProUGUI>().text = "FIND THE RED BOOK FIRST";
    }

    public void PromptLocked()
    {
        this.BeginPrompt();
        this.Prompt.GetComponent<TextMeshProUGUI>().text = "THIS DOOR IS LOCKED";
    }

    public void PromptExit()
    {
        this.BeginPrompt();
        this.Prompt.GetComponent<TextMeshProUGUI>().text = "[E] EXIT";
    }

    public void UnlockDoor()
    {
        this.CanExit = true;
    }

    public void LockDoor()
    {
        this.CanExit = false;
    }

    public bool IsExitOpen()
    {
        return this.CanExit;
    }
}
