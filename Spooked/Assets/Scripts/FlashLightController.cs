// Author: Erik.
// Adapted by Peter Lin.
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashLightController : MonoBehaviour 
{
    private bool Enabled;
    [SerializeField] private GameObject Darkness;
    [SerializeField] private GameObject MaxBright;
    [SerializeField] private GameObject MedBright;
    [SerializeField] private GameObject LowBright;
    [SerializeField] private Light FireLight;
    [SerializeField] private float DurationOn;
    private AudioSource Audio;
    private float Intensity;
    private bool Off;

    public FlashLightController()
    {
        this.Enabled = false;
        this.DurationOn = 0;
        this.Intensity = 0;
        this.Off = true;
    }

    void Start()
    {
        this.FireLight.enabled = false;
        Audio = GetComponent<AudioSource>();
    }

    // If the flashlight is on for too long, notify GameController to make the monster omniscient.
    public bool OverTime()
    {
        if (this.DurationOn > 15)
        {
            return true;
        }
        return false;
    }

    // Cycles the flashlight through different levels of brightness.
    // Higher levels reach OverTime faster.
    private void Toggle()
    {
        this.Intensity++;
        if (this.Intensity > 3)
        {
            this.Intensity = 0;
        }
        switch (this.Intensity)
        {
            case 0:
                this.TurnOff();
                this.Darkness.GetComponent<Image>().color = Color.black;
                break;
            case 1:
                this.Off = false;
                this.FireLight.range = 60;
                this.FireLight.spotAngle = 40;
                this.LowBright.GetComponent<Image>().color = Color.white;
                this.Darkness.GetComponent<Image>().color = new Color(0, 0, 0, 200f/255f);
                break;
            case 2:
                this.Off = false;
                this.FireLight.range = 80;
                this.FireLight.spotAngle = 60;
                this.MedBright.GetComponent<Image>().color = Color.white;
                this.Darkness.GetComponent<Image>().color = new Color(0, 0, 0, 200f/255f);
                break;
            case 3:
                this.Off = false;
                this.FireLight.range = 100;
                this.FireLight.spotAngle = 80;
                this.MaxBright.GetComponent<Image>().color = Color.white;
                this.Darkness.GetComponent<Image>().color = new Color(0, 0, 0, 200f/255f);
                break;
        }
        if (this.Intensity > 0)
        {
            this.Enabled = true;
            this.FireLight.enabled = true;
        }
    }

    public void TurnOff()
    {
        this.Off = true;
        this.Enabled = false;
        this.FireLight.enabled = false;
        this.DurationOn = 0;
        this.Intensity = 0;
        this.LowBright.GetComponent<Image>().color = Color.black;
        this.MedBright.GetComponent<Image>().color = Color.black;
        this.MaxBright.GetComponent<Image>().color = Color.black;
        Debug.Log("Flashlight turned Off");
    }

    public bool IsOff()
    {
        return this.Off;
    }

    void Update()
    {
        // Turn the flashlight on/off.
        if (Input.GetButtonDown("Fire1"))
        {
            this.Toggle();
            Audio.Play();
        }

        if (this.Enabled)
        {
            // Add to time before notifying monster
            this.DurationOn += Time.deltaTime * this.Intensity;
        }
    }
}