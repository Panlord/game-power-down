using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightController : MonoBehaviour 
{
    // Is the flashlight turned on?
    private bool Enabled;
    private Light FireLight;
    private float DurationOn;
    private bool Paused;
    // Optional features that can be added. Remove if not needed.
    private float Battery;
    private float MaxBattery;
    private float DrainRate;
    private float Intensity;

    public FlashLightController()
    {
        this.Enabled = false;
        this.Paused = false;
        this.Battery = 100;
        this.MaxBattery = 100;
        this.DurationOn = 0;
        this.DrainRate = 0;
        this.Intensity = 1;
    }

    void Start()
    {
        this.FireLight = this.gameObject.GetComponent<Light>();
        this.FireLight.enabled = false;
    }

    public bool OverTime()
    {
        if (this.DurationOn > 10)
        {
            return true;
        }
        return false;
    }

    public bool CurrentlyOn()
    {
        return this.Enabled;
    }

    public void TurnOn()
    {
        this.Enabled = true;
        this.FireLight.enabled = true;
        Debug.Log("Flashlight turned on");
    }

    public void TurnOff()
    {
        this.Enabled = false;
        this.FireLight.enabled = false;
        this.DurationOn = 0;
        Debug.Log("Flashlight turned off");
    }

    public void Pause()
    {
        this.Paused = true;
    }

    public void Resume()
    {
        this.Paused = false;
    }

    // Recharge the flashlight batteries.
    public void AddBattery(float extraCapacity)
    {
        this.Battery += extraCapacity;
        if (this.Battery > this.MaxBattery)
        {
            this.Battery = this.MaxBattery;
        }
    }

    void Update()
    {
        if (this.Enabled && !this.Paused)
        {
            // Drain the battery
            this.Battery -= Time.deltaTime * this.DrainRate;
            // Add to time before notifying monster
            this.DurationOn += Time.deltaTime * this.Intensity;
        }
        // Running out of batteries
        if (this.Battery <= 0)
        {
            this.Battery = 0;
            this.TurnOff();
        }
    }
}