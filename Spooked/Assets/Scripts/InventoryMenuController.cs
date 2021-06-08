// Created by Peter Lin.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryMenuController : MonoBehaviour
{
    [SerializeField] private InterfaceController GUI;
    [SerializeField] private ListCreator ItemList;
    [SerializeField] private Inventory PlayerInventory;
    [SerializeField] private Sprite NormalPage;
    [SerializeField] private Sprite CursedPage;
    private GameObject ItemPanel;
    private int MaxItemsOnScreen;
    private int ActiveItem;
    private int ListOffset;

    public void Awake()
    {
        this.ItemPanel = this.transform.Find("ItemPanel").gameObject;
        this.MaxItemsOnScreen = 8;
        this.ActiveItem = 0;
        this.ListOffset = 0;
    }

    public void OnEnable()
    {
        this.ItemList.ResetPosition();
        if (this.PlayerInventory.GetInventory().Count != 0)
        {
            this.ActiveItem = 0;
            this.ItemList.SetActive(this.ActiveItem);
            this.ChangePanel(this.ActiveItem);
        }
    }

    public void OnDisable()
    {
        if (this.PlayerInventory.GetInventory().Count != 0)
        {
            this.ItemList.SetInactive(this.ActiveItem);
        }

        var panelImage = this.ItemPanel.transform.Find("ItemPage");
        panelImage.GetComponent<Image>().sprite = this.NormalPage;
        var panelText = this.ItemPanel.transform.Find("ItemText");
        panelText.GetComponent<TextMeshProUGUI>().text = "There's nothing to show.";
    }

    public void Update()
    {
        var numItems = this.PlayerInventory.GetInventory().Count;

        // Only move list if there are items to show.
        if (numItems != 0)
        {
            // Move down the list if possible.
            if ((Input.GetKeyDown("down") || Input.GetKeyDown(KeyCode.S)) && this.ActiveItem < numItems - 1)
            {
                this.ItemList.SetInactive(this.ActiveItem);
                this.ActiveItem += 1;
                this.ItemList.SetActive(this.ActiveItem);
                this.ChangePanel(this.ActiveItem);

                // List is scrollable.
                if (numItems > this.MaxItemsOnScreen)
                {   
                    // Scroll down.
                    if (this.ActiveItem - this.ListOffset > this.MaxItemsOnScreen - 1)
                    {
                        this.ListOffset += 1;
                        this.ItemList.ScrollDown();
                    }
                }
            // Move up the list if possible.
            } 
            else if ((Input.GetKeyDown("up") || Input.GetKeyDown(KeyCode.W)) && this.ActiveItem > 0)
            {
                this.ItemList.SetInactive(this.ActiveItem);
                this.ActiveItem -= 1;
                this.ItemList.SetActive(this.ActiveItem);
                this.ChangePanel(this.ActiveItem);

                // List is scrollable.
                if (numItems > this.MaxItemsOnScreen)
                {   
                    // Scroll up.
                    if (this.ActiveItem - this.ListOffset < 0 && this.ListOffset != 0)
                    {
                        this.ListOffset -= 1;
                        this.ItemList.ScrollUp();
                    }
                }
            }
        }
    }

    public void ChangePanel(int itemNum)
    {
        var panelText = this.ItemPanel.transform.Find("ItemText");
        var panelImage = this.ItemPanel.transform.Find("ItemPage");
        var item = this.PlayerInventory.GetInventory()[itemNum];

        panelText.GetComponent<TextMeshProUGUI>().text = item.Read();
        if (item.IsCursed())
        {
            panelImage.GetComponent<Image>().sprite = this.CursedPage;
        }
        else
        {
            panelImage.GetComponent<Image>().sprite = this.NormalPage;
        }
    }

    public void Show()
    {
        this.GUI.EndPrompt();
        this.gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        this.gameObject.SetActive(false);
    }
}
