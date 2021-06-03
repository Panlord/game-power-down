using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoreManager : MonoBehaviour 
{
    private List<LoreItem> PossibleEntries;
    private List<LoreItem> LoreInventory;

    public LoreManager()
    {
        this.PossibleEntries = new List<LoreItem>();
        this.LoreInventory = new List<LoreItem>();
        this.PossibleEntries.Add(new LoreItem("Yo"));
        this.PossibleEntries.Add(new LoreItem("Ey"));
        this.PossibleEntries.Add(new LoreItem("Hi"));
    }
    public void Reset()
    {
        this.PossibleEntries.Clear();
        this.LoreInventory.Clear();
        // Add all possible entries back into PossibleEntries.
        this.PossibleEntries.Add(new LoreItem("Yo"));
        this.PossibleEntries.Add(new LoreItem("Ey"));
        this.PossibleEntries.Add(new LoreItem("Hi"));
    } 

    // Generate a lore piece and store into the inventory.
    public void GenerateLore()
    {
        var Index = Random.Range(0, this.PossibleEntries.Capacity);
        var collectedItem = this.PossibleEntries[Index];

        LoreInventory.Add(collectedItem);
        PossibleEntries.Remove(collectedItem);
    }
}

public class LoreItem
{
    private string LoreText;

    public LoreItem(string inputString)
    {
        this.LoreText = inputString;
    }

    public string Read() 
    {
        return LoreText;
    }
}