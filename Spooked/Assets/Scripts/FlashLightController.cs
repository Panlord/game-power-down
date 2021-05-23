using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightController : MonoBehaviour 
{
    // Is the flashlight turned on?
    private bool Enabled;
    private Light FireLight;
    // Optional features that can be added. Remove if not needed.
    private float Battery;
    private float MaxBattery;
    private float DrainRate;
    private float Intensity;
    private float DurationOn;

    public FlashLightController()
    {
        this.Enabled = false;
        this.Battery = 100;
        this.MaxBattery = 100;
        this.DrainRate = 0;
        this.Intensity = 1;
    }

    void Start()
    {
        this.FireLight = this.gameObject.GetComponent<Light>();
        this.FireLight.enabled = false;
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
        Debug.Log("Flashlight turned off");
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
        if (this.Enabled)
        {
            // Code here to show the light

            // Drain the battery
            this.Battery -= Time.deltaTime * this.DrainRate;

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