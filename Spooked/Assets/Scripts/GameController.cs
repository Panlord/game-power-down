using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private FlashLightController FlashLight;
    private bool FlashLightOn;
    [SerializeField] private MapController VisibleMap;
    private bool Paused;
    // Time recorded for storing in the leaderboard.
    private float RecordTime;

    public GameController() 
    {
        this.FlashLightOn = false;
        this.Paused = false;
        this.RecordTime = 0f;
    }
    private void Start()
    {
        this.FlashLight = this.gameObject.AddComponent<FlashLightController>();
        this.VisibleMap = this.gameObject.AddComponent<MapController>();
    }

    // Reset everything for another playthrough.
    private void Reset()
    {

    }

    // Pause the game.
    private void Pause()
    {
        this.Paused = true;
        // What should we do:
        // Change to a new scene?
        // Or make the pause menu in the same scene but make it visible?
        
        // Show the inventory inside the pause menu.
    }

    // Send the player's current location to the monster.
    private void NotifyMonster()
    {

    }

    void Update()
    {
        if (!this.Paused) 
        {
            this.RecordTime += Time.deltaTime;

            // Turn the flashlight on/off.
            if (Input.GetButtonDown("Fire1"))
            {
                if (this.FlashLightOn)
                {
                    this.FlashLight.TurnOff();
                    this.FlashLightOn = false;
                }
                else
                {
                    this.FlashLight.TurnOn();
                    this.FlashLightOn = true;
                }
            }

            // Show or hide the map.
            if (Input.GetButtonDown("Fire2"))
            {
                if (this.VisibleMap.CanSignalMonster())
                {
                    this.VisibleMap.Hide();
                }
                else
                {
                    this.VisibleMap.Show();
                }
            }

            // If the map is out signal the monster.
            if (!this.Paused && this.VisibleMap.CanSignalMonster())
            {
                this.NotifyMonster();
            }
        }
    }
}