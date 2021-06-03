using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour 
{
    [SerializeField] private Button ResumeButton;
    private bool Activated;

    private PauseMenuController()
    {
        this.Activated = false;
    }

    void Start()
    {
        this.ResumeButton.onClick.AddListener(Activate);
    }

    public bool IsActivated()
    {
        return this.Activated;
    }

    public void Activate() 
    {
        this.Activated = true;
    }

    public void Deactivate()
    {
        this.Activated = false;
        this.gameObject.SetActive(false);
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }
}