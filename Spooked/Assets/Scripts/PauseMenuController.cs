using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour 
{
    [SerializeField] private Button ResumeButton;
    [SerializeField] private Button QuitButton;

    private bool Activated;
    private bool Quitting;

    private PauseMenuController()
    {
        this.Activated = false;
        this.Quitting = false;
    }

    void Start()
    {
        this.ResumeButton.onClick.AddListener(Activate);
        this.QuitButton.onClick.AddListener(Quit);
    }

    public bool IsActivated()
    {
        return this.Activated;
    }

    public bool IsQuitting()
    {
        return this.Quitting;
    }

    public void Activate() 
    {
        this.Activated = true;
    }

    private void Quit()
    {
        this.Quitting = true;
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