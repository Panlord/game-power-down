using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour 
{
    [SerializeField] private Button ResumeButton;
    [SerializeField] private Button QuitButton;

    [SerializeField] private Button LoreButton;
    private bool Activated;
    private bool Quitting;
    private bool Lore;

    private PauseMenuController()
    {
        this.Activated = false;
        this.Quitting = false;
        this.Lore = false;
    }

    void Start()
    {
        this.ResumeButton.onClick.AddListener(Activate);
        this.QuitButton.onClick.AddListener(Quit);
        this.LoreButton.onClick.AddListener(LoreMode);
    }

    public bool IsActivated()
    {
        return this.Activated;
    }

    public bool IsQuitting()
    {
        return this.Quitting;
    }

    public bool IsLore()
    {
        return this.Lore;
    }

    public void Activate() 
    {
        this.Activated = true;
    }

    private void Quit()
    {
        this.Quitting = true;
    }
    private void LoreMode()
    {
        this.Lore = true;
    }

    public void OutLore()
    {
        this.Lore = false;
    }

    public void Deactivate()
    {
        this.Activated = false;
        this.Quitting = false;
        this.gameObject.SetActive(false);
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }
}