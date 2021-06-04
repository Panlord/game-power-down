using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroMenuController : MonoBehaviour 
{
    [SerializeField] private Button GoButton;
    private bool Activated;

    private IntroMenuController()
    {
        this.Activated = false;
    }

    void Start()
    {
        this.GoButton.onClick.AddListener(Activate);
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