using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightController : MonoBehaviour 
{
    // Is the flashlight turned on?
    private bool Enabled;
    [SerializeField] private Light FireLight;
    [SerializeField] private float DurationOn;
    private bool Paused;
    // Optional features that can be added. Remove if not needed.
    [SerializeField] private float Battery;
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

    private void TurnOn()
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
        // Turn the flashlight on/off.
        if (Input.GetButtonDown("Fire1"))
        {
            if (this.Enabled)
            {
                this.TurnOff();
            }
            else
            {
                this.TurnOn();
            }
        }

        if (this.Enabled)
        {
            // Drain the battery
            this.Battery -= Time.deltaTime * this.DrainRate;
            // Add to time before notifying monster
            this.DurationOn += Time.deltaTime * this.Intensity;
        }
        // Running out of batteries
        if (this.Battery < 0)
        {
            this.Battery = 0;
            this.TurnOff();
        }
    }
}