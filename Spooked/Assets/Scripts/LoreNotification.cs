using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoreNotification : MonoBehaviour 
{
    [SerializeField] private Button CloseButton;
    [SerializeField] private Image Page;
    [SerializeField] private TextMeshProUGUI LoreText;
    [SerializeField] private Sprite CursedPage;
    [SerializeField] private Sprite NormalPage;
    private bool Activated;

    public LoreNotification()
    {
        this.Activated = false;
    }

    void Start()
    {
        this.CloseButton.onClick.AddListener(Activate);
    }

    // Displays text on the lore screen upon picking up a lore piece.
    public void Set(LoreItem item)
    {
        this.LoreText.text = item.Read();
        // If the text is cursed, show a bloody page instead of a regular one.
        if (item.IsCursed())
        {
            this.Page.sprite = this.CursedPage;
        }
        else
        {
            this.Page.sprite = this.NormalPage;
        }
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
        this.gameObject.SetActive(false);
        this.Activated = false;
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }

     void Update()
    {
        if (Input.GetButtonDown("Use"))
        {
            Activate();
        }
    }
}