// Created by Peter Lin.
// Adapted from https://www.codeneuron.com/creating-a-dynamic-scrollable-list-in-unity/.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ListCreator : MonoBehaviour
{
    [SerializeField] private Inventory PlayerInventory;
    [SerializeField] private Transform SpawnPoint;
    [SerializeField] private GameObject Prefab;
    [SerializeField] private RectTransform Content;
    private int HeightOfEachItem;
    private Color ActiveColor;
    private Color InactiveColor;

    public void Awake()
    {
        this.HeightOfEachItem = 125;
        this.ActiveColor = new Color(190f/255f, 80f/255f, 80f/255f);
        this.InactiveColor = Color.white;
    }

    public void Reset()
    {
        foreach (Transform child in this.SpawnPoint.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    public void AddItem(LoreItem item)
    {
        var newPosY = (this.PlayerInventory.GetInventory().Count - 1) * this.HeightOfEachItem;

        // Size of entire scrollable area.
        // this.Content.sizeDelta = new Vector2(0, newPosY);

        // Instantiate new item as child of SpawnPoint.
        var newItem = Instantiate(Prefab, this.SpawnPoint);

        // Edit position.y of item depending on how many items there are.
        newItem.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, -newPosY, 0);

        // Set name of tab according to item's name.
        newItem.transform.Find("Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>().text = item.GetName();
    }

    public void SetActive(int itemNum)
    {
        var item = this.SpawnPoint.transform.GetChild(itemNum);
        item.transform.Find("Image").GetComponent<Image>().color = this.ActiveColor;
    }

    public void SetInactive(int itemNum)
    {
        var item = this.SpawnPoint.transform.GetChild(itemNum);
        item.transform.Find("Image").GetComponent<Image>().color = Color.white;
    }

    public void ScrollUp()
    {
        var spawnPointRect = this.SpawnPoint.GetComponent<RectTransform>();
        spawnPointRect.anchoredPosition3D += new Vector3(0, -this.HeightOfEachItem, 0);
    }

    public void ScrollDown()
    {
        var spawnPointRect = this.SpawnPoint.GetComponent<RectTransform>();
        spawnPointRect.anchoredPosition3D += new Vector3(0, this.HeightOfEachItem, 0);
    }

    public void ResetPosition()
    {
        var spawnPointRect = this.SpawnPoint.GetComponent<RectTransform>();
        spawnPointRect.anchoredPosition3D = new Vector3(100, -100, 0);
    }
}