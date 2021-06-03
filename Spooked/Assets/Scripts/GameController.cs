using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private FlashLightController FlashLight;
    [SerializeField] private MapController VisibleMap;
    //[SerializeField] private MonsterController Monster;
    [SerializeField] private CharacterController Player;
    [SerializeField] private PlayerMovement PlayerMove;
    [SerializeField] private MouseLook FirstPerson;
    [SerializeField] private DoorRaycast OpenSingleDoor;
    [SerializeField] private DoubleDoorRaycast OpenDoubleDoor;

    [SerializeField] private LoreManager LoreSystem;

    [SerializeField] private GameObject Monster;

    private bool Paused;
    private bool InMenu;
    // Time recorded for storing in the leaderboard.
    private float RecordTime;

    public GameController() 
    {
        this.Paused = false;
        this.InMenu = false;
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
        // FlashLight
        this.FlashLight.TurnOff();
        this.FlashLight.AddBattery(9999);

        // Timer
        this.RecordTime = 0;
        
        // Lore System
        this.LoreSystem.Reset();
    }

    private void DisplayPauseMenu() 
    {

    }

    private void HidePauseMenu()
    {

    }

    private void GameOver()
    {
        this.Pause();

    }

    // Pause or unpause the game.
    private void Pause()
    {
        if (!this.Paused)
        {
            Debug.Log("Game Paused");
            this.Paused = true;
            this.FlashLight.enabled = false;
            this.VisibleMap.enabled = false;
            this.FirstPerson.enabled = false;
            this.PlayerMove.enabled = false;
            this.OpenDoubleDoor.enabled = false;
            this.OpenSingleDoor.enabled = false;
            this.Monster.GetComponent<Animator>().enabled = false;
            this.Monster.GetComponent<MonsterMovement>().enabled = false;
            // Show the pause menu and the inventory.
            // Dim the screen a little?
            // Player should not be able to move or act while paused.
        }
        else
        {
            Debug.Log("Game Resumed");
            this.Paused = false;
            this.FlashLight.enabled = true;
            this.VisibleMap.enabled = true;
            this.FirstPerson.enabled = true;
            this.PlayerMove.enabled = true;
            this.OpenDoubleDoor.enabled = true;
            this.OpenSingleDoor.enabled = true;
            this.Monster.GetComponent<Animator>().enabled = true;
            this.Monster.GetComponent<MonsterMovement>().enabled = true;
            // Unpause the game and make things brighter. 
        }
    }

    // Send the player's current location to the monster.
    private void NotifyMonster()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !this.InMenu)
        {
            this.Pause();
            if (this.Paused)
            {
                this.DisplayPauseMenu();
            }
            else
            {
                this.HidePauseMenu();
            }
        }
        
        if (!this.Paused) 
        {
            this.RecordTime += Time.deltaTime;

            // If the map is out, or the flashlight is on for too long, signal the monster.
            if (this.VisibleMap.CanSignalMonster() || this.FlashLight.OverTime())
            {
                this.NotifyMonster();
            }
        }
    }
}