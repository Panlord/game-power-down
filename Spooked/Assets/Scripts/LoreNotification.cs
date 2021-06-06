using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoreNotification : MonoBehaviour 
{
    [SerializeField] private Button BackButton;
    [SerializeField] private Text LoreText;
    private bool Activated;

    private LoreNotification()
    {
        this.Activated = false;
    }

    void Start()
    {
        this.BackButton.onClick.AddListener(Activate);
    }

    public void SetText(string incomingText)
    {
        this.LoreText.text = incomingText;
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