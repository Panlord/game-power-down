using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private FlashLightController FlashLight;
    [SerializeField] private MapController VisibleMap;
    [SerializeField] private CharacterController Player;
    [SerializeField] private PlayerMovement PlayerMove;
    [SerializeField] private MouseLook FirstPerson;
    [SerializeField] private DoorRaycast OpenSingleDoor;
    [SerializeField] private DoubleDoorRaycast OpenDoubleDoor;
    [SerializeField] private LoreManager LoreSystem;
    [SerializeField] private GameObject Monster;
    [SerializeField] private GameObject PlayerModel;
    [SerializeField] private GameObject HallwayLights;
    [SerializeField] private MainMenuController MainMenu;
    [SerializeField] private PauseMenuController PauseMenu;
    [SerializeField] private IntroMenuController IntroMenu;
    [SerializeField] private EndMenuController EndMenu;

    private bool Paused;

    [SerializeField] private bool HasBook;
    private bool InMenu;
    // Time recorded for storing in the leaderboard.
    private float RecordTime;

    public GameController() 
    {
        this.Paused = false;
        this.InMenu = true;
        this.RecordTime = 0f;
        this.HasBook = false;
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
        // FlashLight:
        this.FlashLight.TurnOff();

        // Map:
        this.VisibleMap.Hide();

        // Timer:
        this.RecordTime = 0;
        
        // Lore System
        //this.LoreSystem.Reset();

        // Player Position:
        this.PlayerModel.transform.position = new Vector3(-6.515f, 0.59f, -4.85f);

        // Mouse Direction:
        this.FirstPerson.ResetView();

        // Hallway Lights and Book Possession:
        this.HallwayLights.SetActive(true);
        this.HasBook = false;
        
        // Monster:
        this.Monster.SetActive(false);
        this.Monster.transform.position = new Vector3(1.535991f, -0.1799999f, -6.159369f);
        this.Monster.GetComponent<Animator>().enabled = false;
        this.Monster.GetComponent<MonsterMovement>().enabled = false;
    }

    private void ReturnToMenu()
    {
        this.MainMenu.Show();
        this.Reset();
        if (!this.Paused)
        {
            this.Pause();
        }
        this.InMenu = true;
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
            this.Monster.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            if (this.Monster.activeSelf)
            {
                this.Monster.GetComponent<MonsterMovement>().Halt();
            }   
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

            if (this.HasBook)
            {
                this.Monster.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                this.Monster.GetComponent<Animator>().enabled = true;
                this.Monster.GetComponent<MonsterMovement>().enabled = true;
                this.Monster.GetComponent<MonsterMovement>().Continue();
            }
        }
    }

    private void Trigger()
    {
        this.HasBook = true;
        this.HallwayLights.SetActive(false);
        this.Monster.SetActive(true);
        this.Monster.GetComponent<Animator>().enabled = true;
        this.Monster.GetComponent<MonsterMovement>().enabled = true;
        this.Monster.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        this.Monster.GetComponent<MonsterMovement>().WarpRandom();
    }

    void Update()
    {
        this.gameObject.transform.position = new Vector3(this.PlayerModel.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        // if (this.gameObject.transform.position.x == this.Monster.transform.position.x && this.Monster.activeSelf)
        // {
        //     this.Pause();
        //     this.EndMenu.Show();
        // }

        if (this.MainMenu.IsActivated())
        {
            this.MainMenu.Deactivate();
            this.IntroMenu.Show();
        }

        if (this.IntroMenu.IsActivated())
        {
            this.Pause();
            this.InMenu = false;
            this.IntroMenu.Deactivate();
        }

        if (this.PauseMenu.IsActivated())
        {
            this.Pause();
            this.PauseMenu.Deactivate();
        }

        if (this.PauseMenu.IsQuitting())
        {
            this.PauseMenu.Deactivate();
            this.ReturnToMenu();
        }

        if (this.EndMenu.IsActivated())
        {
            this.EndMenu.Deactivate();
            this.ReturnToMenu();
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
                this.Monster.GetComponent<MonsterMovement>().GainKnowledge();
            }
            else
            {
                this.Monster.GetComponent<MonsterMovement>().Dumbdown();
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                this.Trigger();
            }
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}