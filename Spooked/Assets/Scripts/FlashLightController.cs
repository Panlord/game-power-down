using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightController : MonoBehaviour 
{
    // Is the flashlight turned on?
    private bool Enabled;
    [SerializeField] private Light FireLight;
    [SerializeField] private float DurationOn;
    private AudioSource Audio;
    private float Intensity;

    public FlashLightController()
    {
        this.Enabled = false;
        this.DurationOn = 0;
        this.Intensity = 0;
    }

    void Start()
    {
        this.FireLight.enabled = false;
        Audio = GetComponent<AudioSource>();
    }

    public bool OverTime()
    {
        if (this.DurationOn > 15)
        {
            return true;
        }
        return false;
    }

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
                break;
            case 1:
                this.FireLight.spotAngle = 20;
                this.FireLight.intensity = 1;
                break;
            case 2:
                this.FireLight.spotAngle = 40;
                this.FireLight.intensity = 1;
                break;
            case 3:
                this.FireLight.spotAngle = 80;
                this.FireLight.intensity = 2;
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
        this.Enabled = false;
        this.FireLight.enabled = false;
        this.DurationOn = 0;
        this.Intensity = 0;
        Debug.Log("Flashlight turned off");
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