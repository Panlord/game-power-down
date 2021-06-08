using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private FlashLightController FlashLight;
    [SerializeField] private CharacterController Player;
    [SerializeField] private PlayerMovement PlayerMove;
    [SerializeField] private MouseLook FirstPerson;
    [SerializeField] private DoorRaycast OpenSingleDoor;
    [SerializeField] private DoubleDoorRaycast OpenDoubleDoor;
    [SerializeField] private GameObject Door;
    [SerializeField] private GameObject[] Doors;
    [SerializeField] private GameObject DoubleDoor;
    [SerializeField] private GameObject[] DoubleDoors;
    [SerializeField] private LoreRaycast OpenLore;
    [SerializeField] private LoreManager LoreSystem;
    [SerializeField] private GameObject Monster;
    [SerializeField] private GameObject PlayerModel;
    [SerializeField] private GameObject HallwayLights;
    [SerializeField] private GameObject Light;
    [SerializeField] private GameObject[] Lights;
    [SerializeField] private GameObject ExitDoorOne;
    [SerializeField] private GameObject ExitDoorTwo;
    [SerializeField] private GameObject ExitDoorThree;
    [SerializeField] private GameObject InteractableObjects;
    [SerializeField] private GameObject TheBook;
    [SerializeField] private GameObject JumpScare;
    [SerializeField] private MonsterCollision MonsterCollider;
    [SerializeField] private MainMenuController MainMenu;
    [SerializeField] private PauseMenuController PauseMenu;
    [SerializeField] private IntroMenuController IntroMenu;
    [SerializeField] private EndMenuController EndMenu;
    [SerializeField] private LoreNotification ShowLore;
    [SerializeField] private LoreMenuController LoreMenu;

    private bool Paused;
    private bool HasBook;
    private bool Triggered;
    private bool InMenu;
    private bool CanScare;

    // Time recorded for storing in the leaderboard.
    private float RecordTime;
    private float ScareDuration;


    public GameController() 
    {
        this.Paused = false;
        this.InMenu = true;
        this.ScareDuration = 0f;
        this.RecordTime = 0f;
        this.HasBook = false;
        this.Triggered = false;
    }

    private void Start()
    {
        Lights = GameObject.FindGameObjectsWithTag("Light");
        Doors = GameObject.FindGameObjectsWithTag("Door");
        DoubleDoors = GameObject.FindGameObjectsWithTag("DoubleDoor");
        this.SetWinningDoor();
        this.SetSpawn();
        this.Pause();
    }

    // Randomly choose among the three exits which one will be the right exit.
    private void SetWinningDoor()
    {
        List<GameObject> randDoors = new List<GameObject>();
        randDoors.Add(this.ExitDoorOne);
        randDoors.Add(this.ExitDoorTwo);
        randDoors.Add(this.ExitDoorThree);
        var j = Random.Range(0, 3);
        randDoors[j].tag = "ExitDoor";
        randDoors[j].transform.GetChild(0).gameObject.tag = "ExitDoor";
        randDoors[j].transform.GetChild(1).gameObject.tag = "ExitDoor";
        randDoors.Remove(randDoors[j]);
        for (int i = 0; i < 2; i++)
        {
            j = Random.Range(0, randDoors.Count);
            randDoors[j].tag = "LockedExit";
            randDoors[j].transform.GetChild(0).gameObject.tag = "LockedExit";
            randDoors[j].transform.GetChild(1).gameObject.tag = "LockedExit";
            randDoors.Remove(randDoors[j]);
        }
    }

    // Randomly spawn the player in one of three locations.
    private void SetSpawn()
    {
        var startLocation = Random.Range(0, 3);
        switch (startLocation) 
        {
            case 0:
                this.PlayerModel.transform.position = new Vector3(-30.30545f, 0.6226647f, 12.64777f);
                break;
            case 1:
                this.PlayerModel.transform.position = new Vector3(-22.12322f, 0.5800078f, -5.897281f);
                break;
            case 2:
                this.PlayerModel.transform.position = new Vector3(25.33517f, 0.5800077f, -33.95593f);
                break;
        }
    }

    // Make all Lore Pieces and the book spawn again.
    private void RespawnAll()
    {
        for (int i = 0; i < 20; i++)
        {
            this.InteractableObjects.transform.GetChild(i).gameObject.SetActive(true);
        }
        this.TheBook.SetActive(true);
    }

    // Close all doors.
    private void CloseAllDoors()
    {
        foreach (GameObject Door in Doors)
        {
            var door = Door.GetComponent<DoorController>();
            if (door.IsOpen())
            {
                door.Close();
            }
        }
        foreach (GameObject DoubleDoor in DoubleDoors)
        {
            var doubleDoor = DoubleDoor.GetComponent<DoubleDoorController>();
            if (doubleDoor.IsOpen())
            {
                doubleDoor.Close();
            }
        }
    }

    // Reset everything for another playthrough.
    // This should always be called upon returning to the main menu.
    private void Reset()
    {
        // FlashLight:
        this.FlashLight.TurnOff();

        // Timer:
        this.RecordTime = 0f;
        TimerController.timer.ResetTimer();
        
        // Lore System
        this.LoreSystem.Reset();
        this.RespawnAll();

        // Player Position:
        this.SetSpawn();

        // Mouse Direction:
        this.FirstPerson.ResetView();

        // Hallway Lights and Book Possession:
        this.HallwayLights.SetActive(true);
        this.HasBook = false;
        
        // Turn back on the lights.
        LightsOn();

        // Close all the doors.
        CloseAllDoors();

        // Monster:
        this.Monster.SetActive(false);
        this.Monster.transform.position = new Vector3(1.535991f, -0.1799999f, -6.159369f);
        this.Monster.GetComponent<Animator>().enabled = false;
        this.Monster.GetComponent<MonsterMovement>().enabled = false;

        // Exits:
        this.SetWinningDoor();

        // Misc:
        this.Triggered = false;
    }

    // Return to the Main Menu.
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
            this.FirstPerson.enabled = false;
            this.PlayerMove.enabled = false;
            this.OpenDoubleDoor.enabled = false;
            this.OpenSingleDoor.enabled = false;
            this.OpenLore.enabled = false;
            this.Monster.GetComponent<Animator>().enabled = false;
            this.Monster.GetComponent<MonsterMovement>().enabled = false;
            this.Monster.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            TimerController.timer.PauseTime();
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
            this.FirstPerson.enabled = true;
            this.PlayerMove.enabled = true;
            this.OpenDoubleDoor.enabled = true;
            this.OpenSingleDoor.enabled = true;
            this.OpenLore.enabled = true;
            TimerController.timer.ContinueTime();
            if (this.Triggered)
            {
                this.Monster.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                this.Monster.GetComponent<Animator>().enabled = true;
                this.Monster.GetComponent<MonsterMovement>().enabled = true;
                this.Monster.GetComponent<MonsterMovement>().Continue();
            }

        }
    }

    // Turn off ALL the lights.
    private void LightsOut()
    {
        foreach (GameObject Light in Lights)
        {
            var light = Light.GetComponent<Light>();
            light.enabled = false;
        }
    }

    // Turn on ALL the lights.
    private void LightsOn()
    {
        foreach (GameObject Light in Lights)
        {
            var light = Light.GetComponent<Light>();
            light.enabled = true;
        }
    }

    // Shut off the lights and summon the monster.
    private void Trigger()
    {
        this.HallwayLights.SetActive(false);
        LightsOut();
        this.Monster.SetActive(true);
        this.Monster.GetComponent<Animator>().enabled = true;
        this.Monster.GetComponent<MonsterMovement>().enabled = true;
        this.Monster.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        this.Triggered = true;
        this.CloseAllDoors();
        this.Monster.GetComponent<MonsterMovement>().WarpRandom();
    }
    private void ActivateScare()
    {
        this.EndMenu.Show(false, this.RecordTime);
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
            TimerController.timer.BeginTimer();
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

        // Was "Inventory" pressed on the Pause menu?
        if (this.PauseMenu.IsLore())
        {
            this.InMenu = true;
            this.PauseMenu.OutLore();
            this.PauseMenu.Deactivate();
            this.LoreMenu.Show();

        }

        // Was "Close" pressed when viewing all the lore you have?
        if (this.LoreMenu.IsActivated())
        {
            this.InMenu = false;
            this.LoreMenu.Deactivate();
            this.PauseMenu.Show();
        }


        // Was "Return to Menu" pressed on the End Menu?
        if (this.EndMenu.IsActivated())
        {
            this.EndMenu.Deactivate();
            this.ReturnToMenu();
        }

        // Was "Close" pressed when viewing a Lore you just got?
        if (this.ShowLore.IsActivated())
        {
            // Unpause the game and remove the lore from the screen.
            this.ShowLore.Deactivate();
            this.Pause();
            this.InMenu = false;
            // If that lore piece was cursed (Monster POV), shut off lights and spawn monster.
            if (this.LoreSystem.ReadLore()[this.LoreSystem.ReadLore().Count - 1].IsCursed() && !this.Triggered)
            {
                this.Trigger();
            }
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

        // The user interacted with one of the exits.
        if (this.OpenDoubleDoor.ExitCheck() > 0)
        {
            // If they don't have the book.
            if (!this.HasBook)
            {
                Debug.Log("You haven't gotten the book yet!");
                this.OpenDoubleDoor.Reset();
            }

            // If the user has the book and found the right exit.
            if (this.OpenDoubleDoor.ExitCheck() == 1)
            {
                this.OpenDoubleDoor.Reset();
                this.InMenu = true;
                this.Pause();
                this.EndMenu.Show(true, this.RecordTime);
                this.OpenDoubleDoor.Reset();
            }
            
            // If that's the wrong exit (it's locked).
            else if (this.OpenDoubleDoor.ExitCheck() == 2)
            {
                this.OpenDoubleDoor.Reset();
                Debug.Log("This exit is locked.");
            }
        }

        // If the player interacted with a lore piece.
        if (this.OpenLore.GotLore())
        {
            this.OpenLore.ResetLore();
            this.Pause();
            this.InMenu = true;
            this.LoreSystem.GenerateLore();
            var obtainedLore = this.LoreSystem.ReadLore()[this.LoreSystem.ReadLore().Count - 1];
            this.ShowLore.SetText(obtainedLore.Read());
            this.ShowLore.Show();
        }
        else if (this.OpenLore.GotBook())
        {
            if (!this.Triggered)
            {
                this.Trigger();
            }
            this.HasBook = true;
            this.OpenLore.ResetBook();
        }

        if (this.CanScare)
        {
            this.JumpScare.SetActive(true);
            this.ScareDuration += Time.deltaTime;
            if (ScareDuration >= 5)
            {
                this.JumpScare.SetActive(false);
                this.CanScare = false;
                this.ScareDuration = 0;
                this.EndMenu.Show(false, this.RecordTime);
            }            
        } 

        if (!this.Paused) 
        {
            this.RecordTime += Time.deltaTime;
            Cursor.lockState = CursorLockMode.Locked;

            this.MonsterCollider.gameObject.transform.position = this.PlayerModel.transform.position;

            if (this.MonsterCollider.Hit())
            {
                this.JumpScare.SetActive(true);
                this.Pause();
                this.CanScare = true;
                this.InMenu = true;
                this.MonsterCollider.Reset();
            }

            // If the map is out, or the flashlight is on for too long, signal the monster.
            if (this.FlashLight.OverTime())
            {
                this.Monster.GetComponent<MonsterMovement>().GainKnowledge();
            }
            else
            {
                this.Monster.GetComponent<MonsterMovement>().Dumbdown();
            }

            // If the user is taking too long to find the book, shut off the lights and summon the monster.
            if (this.RecordTime >= 60 && !this.Triggered)
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
