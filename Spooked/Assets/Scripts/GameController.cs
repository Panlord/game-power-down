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

    [SerializeField] private MainMenuController MainMenu;

    [SerializeField] private PauseMenuController PauseMenu;


    [SerializeField] private bool Paused;
    private bool InMenu;
    // Time recorded for storing in the leaderboard.
    private float RecordTime;

    public GameController() 
    {
        this.Paused = false;
        this.InMenu = true;
        this.RecordTime = 0f;
    }

    private void Start()
    {
        this.VisibleMap = this.gameObject.AddComponent<MapController>();
        this.Pause();
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

        this.Pause();
    }

    private void GameOver()
    {

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
        }
    }

    // Send the player's current location to the monster.
    private void NotifyMonster()
    {

    }

    void Update()
    {
        //this.gameObject.transform.position = t
        if (this.MainMenu.IsActivated())
        {
            this.Pause();
            this.InMenu = false;
            this.MainMenu.Deactivate();
        }

        if (this.PauseMenu.IsActivated())
        {
            this.Pause();
            this.PauseMenu.Deactivate();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !this.InMenu)
        {
            this.Pause();
            if (this.Paused)
            {
                this.PauseMenu.Show();
            }
            else
            {
                this.PauseMenu.Deactivate();
            }
        }

        if (!this.Paused) 
        {
            this.RecordTime += Time.deltaTime;
            Cursor.lockState = CursorLockMode.Locked;
            // If the map is out, or the flashlight is on for too long, signal the monster.
            if (this.VisibleMap.CanSignalMonster() || this.FlashLight.OverTime())
            {
                this.NotifyMonster();
            }
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}