// Created by Peter Lin.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private LoreManager LoreSystem;
    [SerializeField] private ListCreator InventoryMenuList;
    private List<LoreItem> Items;
    private bool IsLoreObtained;
    private bool IsBookCollected;

    public void Start()
    {
        this.Items = new List<LoreItem>();
        this.IsLoreObtained = false;
        this.IsBookCollected = false;
    }

    public List<LoreItem> GetInventory()
    {
        return this.Items;
    }

    public void Reset()
    {
        this.IsBookCollected = false;
        this.Items.Clear();
        this.LoreSystem.Reset();
        this.InventoryMenuList.Reset();
    }

    public void CollectBook()
    {
        this.IsBookCollected = true;
    }

    public void CollectItem()
    {
        this.IsLoreObtained = true;

        // Generate new lore piece and add it to inventory.
        var newItem = this.LoreSystem.GenerateLore();
        this.Items.Add(newItem);

        // Create new tab in inventory menu for new item.
        this.InventoryMenuList.AddItem(newItem);
    }

    public bool GotLore()
    {
        return this.IsLoreObtained;
    }

    public void ResetLore()
    {
        this.IsLoreObtained = false;
    }

    public bool GotBook()
    {
        return this.IsBookCollected;
    }

    public void ResetBook()
    {
        this.IsBookCollected = false;
    }
}