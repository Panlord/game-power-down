// Author: Erik.
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndMenuController : MonoBehaviour 
{
    [SerializeField] private Button MenuButton;
    [SerializeField] private Button ExitButton;
    [SerializeField] private TextMeshProUGUI ResultText;

    [SerializeField] private bool Activated;

    private string WinText;

    private string LoseText;

    private EndMenuController()
    {
        this.Activated = false;
        this.WinText = "[Report]\n\nAn individual has turned in a sketchbook to the police that they claimed was from that abandoned building in town.\n\nWe turned it over to a white hat practitioner of the occult, who freed all the individuals inside. We noted in particular that the woman on the first page was suffering from a disease we once considered to be incurable. She has been provided the proper treatment that was discovered recently. The other victims were treated and returned to their homes.\n\nOne particular victim claimed to be the assistant of a lost professor and urged us to investigate the building. We sent a full search party and uncovered nothing.\n\nBy the request of the community, we had the building demolished.";
        this.LoseText = "[Report]\n\nA building considered abandoned by the city was found ablaze a few nights ago. After the Fire Department’s timely response, investigators went to work searching the collapsed remains. \n\nAmong the destroyed lab equipment investigators procured a charred, unbound sketchbook containing pictures matching that of individuals reported missing not too long ago.\n\nOn the first page was a woman who was matched to the wife of a particular professor whom the world lost contact with a long time ago. Investigators opened an inquiry into his whereabouts.\n\nThe last page was harshly destroyed, but investigators were able to partially piece it back together. The resulting image was matched with an individual a bystander claimed they saw wandering around that building one night.\n\nOne investigator claims that they saw a large, shadowy figure run into the nearby woods, but the existence of that entity has not been confirmed.";
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
        Debug.Log("clicked");
        this.Activated = true;
    }

    public void Deactivate()
    {
        this.Activated = false;
        this.gameObject.SetActive(false);
    }

    public void Show(bool Victory, float recordTime)
    {
        if (Victory)
        {
            this.ResultText.text = this.WinText + "\n\nYou escaped in " + Math.Round(recordTime, 2) + " seconds.";
        }
        else
        {
            this.ResultText.text = this.LoseText + "\n\nYou survived for " + Math.Round(recordTime, 2) + " seconds.";
        }

        this.gameObject.SetActive(true);
    }
}