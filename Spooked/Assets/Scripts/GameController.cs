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
    [SerializeField] private GameObject ExitDoorOne;
    [SerializeField] private GameObject ExitDoorTwo;
    [SerializeField] private GameObject ExitDoorThree;


    private bool Paused;

    private bool HasBook;
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
        this.SetWinningDoor();
        this.Pause();
    }

    private void SetWinningDoor()
    {
        List<GameObject> Doors = new List<GameObject>();
        Doors.Add(this.ExitDoorOne);
        Doors.Add(this.ExitDoorTwo);
        Doors.Add(this.ExitDoorThree);
        var j = Random.Range(0, 3);
        Doors[j].tag = "ExitDoor";
        Doors[j].transform.GetChild(0).gameObject.tag = "ExitDoor";
        Doors[j].transform.GetChild(1).gameObject.tag = "ExitDoor";
        Doors.Remove(Doors[j]);
        for (int i = 0; i < 2; i++)
        {
            j = Random.Range(0, Doors.Count);
            Doors[j].tag = "LockedExit";
            Doors[j].transform.GetChild(0).gameObject.tag = "LockedExit";
            Doors[j].transform.GetChild(1).gameObject.tag = "LockedExit";
            Doors.Remove(Doors[j]);
        }
    }

    // Reset everything for another playthrough.
    // This should always be called upon returning to the main menu.
    private void Reset()
    {
        // FlashLight:
        this.FlashLight.TurnOff();

        // Map:
        this.VisibleMap.Hide();

        // Timer:
        this.RecordTime = 0f;
        
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

        // Exits:
        this.SetWinningDoor();
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
        // Map Logic.
        // Was "Start" pressed on the main menu?
        if (this.MainMenu.IsActivated())
        {
            this.MainMenu.Deactivate();
            this.IntroMenu.Show();
        }

        // Was "Go" pressed on the Introduction?
        if (this.IntroMenu.IsActivated())
        {
            this.Pause();
            this.InMenu = false;
            this.IntroMenu.Deactivate();
        }

        // Was "Resume" pressed on the Pause menu?
        if (this.PauseMenu.IsActivated())
        {
            this.Pause();
            this.PauseMenu.Deactivate();
        }

        // Was "Quit" pressed on the Pause menu?
        if (this.PauseMenu.IsQuitting())
        {
            this.PauseMenu.Deactivate();
            this.ReturnToMenu();
        }

        // Was "Return to Menu" pressed on the End Menu?
        if (this.EndMenu.IsActivated())
        {
            this.EndMenu.Deactivate();
            this.ReturnToMenu();
        }

        // Pause the game, or unpause if on the Pause Menu.
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

        // Have victory conditions been met?
        if (this.OpenDoubleDoor.ExitCheck() > 0)
        {
            if (!this.HasBook)
            {
                Debug.Log("You haven't gotten the book yet!");
                this.OpenDoubleDoor.Reset();
            }

            if (this.OpenDoubleDoor.ExitCheck() == 1)
            {
                this.OpenDoubleDoor.Reset();
                this.Pause();
                this.EndMenu.Show();
                this.OpenDoubleDoor.Reset();
            }
            else if (this.OpenDoubleDoor.ExitCheck() == 2)
            {
                this.OpenDoubleDoor.Reset();
                Debug.Log("This exit is locked.");
            }

        }

        if (!this.Paused) 
        {
            this.RecordTime += Time.deltaTime;
            Cursor.lockState = CursorLockMode.Locked;

            if (this.PlayerModel.transform.position.x == this.Monster.transform.position.x && this.Monster.activeSelf)
            {
                this.Pause();
                this.EndMenu.Show();
            }

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