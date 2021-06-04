using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndMenuController : MonoBehaviour 
{
    [SerializeField] private Button MenuButton;
    [SerializeField] private Button ExitButton;
    private bool Activated;

    private EndMenuController()
    {
        this.Activated = false;
    }

    void Start()
    {
        this.MenuButton.onClick.AddListener(Activate);
        this.ExitButton.onClick.AddListener(Application.Quit);
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