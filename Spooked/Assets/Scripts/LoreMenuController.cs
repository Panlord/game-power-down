using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoreMenuController : MonoBehaviour 
{
    [SerializeField] private Button BackButton;
    [SerializeField] private Dropdown LoreDropDown;
    [SerializeField] private LoreManager LoreCollection;
    [SerializeField] private Text DisplayText;
    private bool Activated;

    private LoreMenuController()
    {
        this.Activated = false;
    }

    void Start()
    {
        this.BackButton.onClick.AddListener(Activate);
        this.LoreDropDown.onValueChanged.AddListener(delegate{ChangeText();});
    }

    void OnEnable()
    {
        // var loreList = this.LoreCollection.ReadLore();
        // var addList = new List<string>();
        // this.LoreDropDown.ClearOptions();
        // for (int i = 0; i < loreList.Count; i++)
        // {
        //     addList.Add(loreList[i].GetName());
        // }
        // Debug.Log(addList.Count);
        // this.LoreDropDown.AddOptions(addList);   
        // this.ChangeText();
    }

    private void ChangeText()
    {
        // var loreList = this.LoreCollection.ReadLore();
        // if (loreList.Count == 1)
        // {
        //     this.DisplayText.text = loreList[0].Read();
        // }
        // else if (loreList.Count > 1)
        // {
        //     var Name = this.LoreDropDown.options[this.LoreDropDown.value].text;
        //     for (int i = 0; i < loreList.Count; i++)
        //     {
        //         if (loreList[i].GetName() == Name)
        //         {
        //             this.DisplayText.text = loreList[i].Read();
        //             break;
        //         }
        //     }
        // }
        // else
        // {
        //     this.DisplayText.text = "This is where you would come to read any items you might have picked up.";
        // }
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