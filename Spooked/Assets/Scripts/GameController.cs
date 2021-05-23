using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private FlashLightController FlashLight;
    [SerializeField] private MapController VisibleMap;
    //[SerializeField] private MonsterController Monster;
    [SerializeField] private CharacterController Player;

    private bool Paused;
    // Time recorded for storing in the leaderboard.
    private float RecordTime;

    public GameController() 
    {
        this.Paused = false;
        this.RecordTime = 0f;
    }

    private void Start()
    {
        // this.FlashLight = this.gameObject.AddComponent<FlashLightController>();
        this.VisibleMap = this.gameObject.AddComponent<MapController>();
    }

    // Reset everything for another playthrough.
    // This should always be called upon returning to the main menu.
    public void Reset()
    {
        this.gameObject.AddComponent<GameController>();
        Destroy(this);
    }

    // Pause the game.
    private void Pause()
    {
        if (!this.Paused)
        {
            this.Paused = true;
            // Show the pause menu and the invntory.
            // Dim the screen a little?
            // Player should not be able to move or act while paused.
        }
        else
        {
            this.Paused = false;
            // Unpause the game and make things brighter. 
        }
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
                if (this.FlashLight.CurrentlyOn())
                {
                    this.FlashLight.TurnOff();
                }
                else
                {
                    this.FlashLight.TurnOn();
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
            if (this.VisibleMap.CanSignalMonster())
            {
                this.NotifyMonster();
            }
        }
    }
}