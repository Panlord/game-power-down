// Author: Erik.
// Base was completed by Erik. Some methods added by Aaron. Optimized by Peter.
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Player references.
    [SerializeField] private MouseLook FirstPerson;
    [SerializeField] private CharacterController Player;
    [SerializeField] private Inventory PlayerInventory;
    [SerializeField] private GameObject PlayerModel;
    [SerializeField] private PlayerMovement PlayerMove;

    // Monster references.
    [SerializeField] private GameObject Monster;
    [SerializeField] private MonsterCollision MonsterCollider;

    // Camera references.
    [SerializeField] private Camera MainCamera;
    [SerializeField] private Camera MainMenuCamera;

    // In-game object references.
    private GameObject[] Doors;
    private GameObject[] DoubleDoors;
    private GameObject[] Lights;
    [SerializeField] private GameObject Book;
    [SerializeField] private FlashLightController FlashLight;
    [SerializeField] private GameObject HallwayLights;
    [SerializeField] private GameObject InteractableObjects;
    [SerializeField] private GameObject JumpScare;
    
    // Menu / UI references.
    [SerializeField] private EndMenuController EndMenu;
    [SerializeField] private InterfaceController GUI;
    [SerializeField] private IntroMenuController IntroMenu;
    [SerializeField] private InventoryMenuController InventoryMenu;
    [SerializeField] private InteractiveItemManager ItemController;
    [SerializeField] private MainMenuController MainMenu;
    [SerializeField] private PauseMenuController PauseMenu;
    [SerializeField] private LoreNotification ShowLore;
    [SerializeField] private TimerController TimerControl;
    [SerializeField] private float SafetyPeriod = 120.0f;

    // Game state logic variables.
    private bool CanScare;
    private bool HasBook;
    private bool InMainMenu;
    private bool MonsterTriggered;
    private bool Paused;

    // Time recorded for storing in the leaderboard.
    private float RecordTime;
    private float ScareDuration;

    public GameController() 
    {
        this.InMainMenu = true;
        this.HasBook = false;
        this.Paused = false;
        this.MonsterTriggered = false;

        this.RecordTime = 0.0f;
        this.ScareDuration = 0.0f;
    }

    private void Start()
    {
        this.Doors = GameObject.FindGameObjectsWithTag("Door");
        this.DoubleDoors = GameObject.FindGameObjectsWithTag("DoubleDoor");
        this.Lights = GameObject.FindGameObjectsWithTag("Light");

        this.SetWinningDoor();
        this.SetSpawn();
        this.RespawnAll();
        this.Pause();
    }

    // Randomly choose among the three exits which one will be the right exit.
    private void SetWinningDoor()
    {
        var exitDoors = GameObject.FindGameObjectsWithTag("LockedExit");

        int exitIndex = Random.Range(0, exitDoors.Length);
        var exit = exitDoors[exitIndex].transform.parent.gameObject;
        exit.tag = "ExitDoor";

        Debug.Log("Exit door:" + exit.transform.parent.name);
    }

    // Randomly spawn the player in one of three locations.
    private void SetSpawn()
    {
        int startLocation = Random.Range(0, 3);
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
        var randIndex = Random.Range(0, 21);
        var bookObjects = GameObject.FindGameObjectsWithTag("CollectibleItem");

        for (int i = 0; i < 20; i++)
        {
            this.InteractableObjects.transform.GetChild(i).gameObject.SetActive(true);
        }
        this.Book.SetActive(true);

        if (randIndex < 20)
        {
            var randObject = bookObjects[randIndex];
            Debug.Log(randObject.name);
            var randPos = randObject.transform.position;
            randObject.transform.position = this.Book.transform.position;
            this.Book.transform.position = randPos;
            Debug.Log(randObject.transform.position);
            Debug.Log(this.Book.transform.position);
        }
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

    // Turn off ALL the lights.
    private void LightsOut()
    {
        foreach (GameObject light in Lights)
        {
            light.GetComponent<Light>().enabled = false;
        }
    }

    // Turn on ALL the lights.
    private void LightsOn()
    {
        foreach (GameObject light in Lights)
        {
            light.GetComponent<Light>().enabled = true;
        }
    }

    // Reset everything for another playthrough.
    // This should always be called upon returning to the main menu.
    private void Reset()
    {
        // FlashLight:
        this.FlashLight.TurnOff();

        // Timer:
        this.RecordTime = 0.0f;
        this.ScareDuration = 0.0f;
        this.TimerControl.ResetTimer();
        
        // Inventory:
        this.PlayerInventory.Reset();
        this.RespawnAll();

        // Player Position:
        this.SetSpawn();

        // Mouse Direction:
        this.FirstPerson.ResetView();

        // Hallway Lights and Book Possession:
        this.HallwayLights.SetActive(true);
        this.HasBook = false;

        // Close all the doors.
        CloseAllDoors();
        
        // Turn back on the lights.
        LightsOn();

        // Monster:
        this.Monster.SetActive(false);
        this.Monster.transform.position = new Vector3(1.535991f, -0.1799999f, -6.159369f);
        this.Monster.GetComponent<Animator>().enabled = false;
        this.Monster.GetComponent<MonsterMovement>().enabled = false;

        // Exits:
        GameObject.FindGameObjectsWithTag("ExitDoor")[0].tag = "Untagged";
        this.SetWinningDoor();

        // Misc:
        this.PlayerMove.ResetStam();
        this.MonsterTriggered = false;
        this.GUI.EndPrompt();
    }

    // Return to the Main Menu.
    private void ReturnToMenu()
    {
        this.MainMenu.Show();
        this.MainMenuCamera.gameObject.SetActive(true);
        this.MainCamera.gameObject.SetActive(false);
        this.Reset();
        if (!this.Paused)
        {
            this.Pause();
        }
        this.InMainMenu = true;
    }

    // Pause or unpause the game.
    private void Pause()
    {
        // Pause game and monster.
        if (!this.Paused)
        {
            Debug.Log("Game Paused");
            this.GUI.EndPrompt();
            this.TimerControl.PauseTime();
            this.Monster.GetComponent<Animator>().enabled = false;
            this.Monster.GetComponent<MonsterMovement>().enabled = false;
            this.Monster.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            
            if (this.Monster.activeSelf)
            {
                this.Monster.GetComponent<MonsterMovement>().Halt();
            }
        // Unpause game and monster.
        }
        else
        {
            Debug.Log("Game Resumed");
            this.TimerControl.ContinueTime();
            if (this.MonsterTriggered)
            {
                this.Monster.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                this.Monster.GetComponent<Animator>().enabled = true;
                this.Monster.GetComponent<MonsterMovement>().enabled = true;
                this.Monster.GetComponent<MonsterMovement>().Continue();
            }
        }

        this.FlashLight.enabled = this.Paused;
        this.FirstPerson.enabled = this.Paused;
        this.PlayerMove.enabled = this.Paused;
        this.Player.gameObject.GetComponent<Footsteps>().enabled = this.Paused;
        this.ItemController.enabled = this.Paused;
        this.Paused = !this.Paused;
    }

    // If most recent lore piece was cursed (Monster POV), shut off lights and spawn monster.
    private void CheckCursedLore()
    {
        var inventory = this.PlayerInventory.GetInventory();
        if (inventory[inventory.Count - 1].IsCursed() && !this.MonsterTriggered)
        {
            Debug.Log("Trigger mosnter via curse");
            this.TriggerMonster();
        }
    }

    // Shut off the lights and summon the monster.
    private void TriggerMonster()
    {
        this.CloseAllDoors();
        this.LightsOut();
        this.HallwayLights.SetActive(false);
        
        this.Monster.SetActive(true);
        this.Monster.GetComponent<Animator>().enabled = true;
        this.Monster.GetComponent<MonsterMovement>().enabled = true;
        this.Monster.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        this.MonsterTriggered = true;
        this.Monster.GetComponent<MonsterMovement>().WarpRandom();
    }

    void Update()
    {
        // Map Logic.
        // Was "Start" pressed on the main menu?
        if (this.MainMenu.IsActivated())
        {
            this.MainMenuCamera.gameObject.SetActive(false);
            this.MainCamera.gameObject.SetActive(true);
            this.MainMenu.Deactivate();
            this.IntroMenu.Show();
            this.HallwayLights.SetActive(true);
        }

        // Was "Go" pressed on the Introduction?
        if (this.IntroMenu.IsActivated())
        {
            this.Pause();
            this.InMainMenu = false;
            this.IntroMenu.Deactivate();
            this.TimerControl.BeginTimer();
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

        // Was "Close" pressed when viewing a Lore you just got?
        if (this.ShowLore.IsActivated())
        {
            // Unpause the game and remove the lore from the screen.
            this.Pause();
            this.ShowLore.Deactivate();
            this.CheckCursedLore();
        }

        // Pause the game.
        if (Input.GetButtonDown("Cancel") && !this.InMainMenu)
        {
            if (!this.Paused)
            {   
                this.GUI.EndPrompt();
                this.Pause();
                this.PauseMenu.Show();
            }
            else
            {
                // Close all open menus.
                this.Pause();
                this.PauseMenu.Deactivate();
                if (this.InventoryMenu.IsOpen())
                {   
                    this.InventoryMenu.Deactivate();
                    this.FlashLight.gameObject.transform.Find("Brightness Setting").gameObject.SetActive(true);
                }
                if (this.ShowLore.IsOpen())
                {
                    this.ShowLore.Deactivate();
                    this.CheckCursedLore();
                }
            }
        }

        // Open / close inventory menu.
        if (Input.GetButtonDown("Inventory") && !this.InMainMenu)
        {
            this.Pause();
            if (this.Paused)
            {
                this.GUI.EndPrompt();
                this.InventoryMenu.Show();
                this.FlashLight.gameObject.transform.Find("Brightness Setting").gameObject.SetActive(false);
            }
            else
            {
                this.InventoryMenu.Deactivate();
                this.FlashLight.gameObject.transform.Find("Brightness Setting").gameObject.SetActive(true);
            }
        }

        // The user interacted with one of the exits.
        var exitDoors = GameObject.FindGameObjectsWithTag("LockedExit");
        foreach (GameObject door in exitDoors)
        {
            var doorControl = door.GetComponent<ExitDoorController>();
            var exitCheck = doorControl.ExitCheck(this.HasBook);

            switch (exitCheck)
            {
                // If they don't have the book.
                case 0:
                    Debug.Log("You haven't gotten the book yet!");
                    // GUI prompt get book first.
                    break;
                // If that's the wrong exit (it's locked).
                case 1:
                    Debug.Log("This exit is locked.");
                    // GUI prompt exit is locked.
                    break;
                // If the user has the book and found the right exit.
                case 2:
                    this.InMainMenu = true;
                    this.Pause();
                    this.EndMenu.Show(true, this.RecordTime);
                    break;
                default:
                    break;
            }
        }

        // If the player interacted with a lore piece.
        if (this.PlayerInventory.GotLore())
        {
            // Add the lore piece to the inventory and display it on the screen.
            this.PlayerInventory.ResetLore();
            this.Pause();
            var inventory = this.PlayerInventory.GetInventory();
            var obtainedLore = inventory[inventory.Count - 1];
            this.ShowLore.Set(obtainedLore);
            this.ShowLore.Show();
        }
        else if (this.PlayerInventory.GotBook())
        {
            // Trigger the monster, and allow the player to use exits.
            if (!this.MonsterTriggered)
            {
                this.TriggerMonster();
            }
            this.HasBook = true;
            this.PlayerInventory.ResetBook();
        }

        // If the jumpscare is active.
        if (this.CanScare)
        {
            this.JumpScare.SetActive(true);
            this.ScareDuration += Time.deltaTime;
            // Close the jumpscare after 5 seconds and show the end screen.
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

            // If the player gets hit by the monster.
            if (this.MonsterCollider.Hit())
            {
                // Freeze the screen and make the jump scare active.
                this.JumpScare.SetActive(true);
                this.JumpScare.GetComponent<AudioSource>().Play();
                this.Pause();
                this.CanScare = true;
                this.InMainMenu = true;
                this.MonsterCollider.Reset();
            }

            // If the flashlight is on for too long, signal the monster.
            if (this.FlashLight.OverTime())
            {
                this.Monster.GetComponent<MonsterMovement>().GainKnowledge();
            }
            else
            {
                this.Monster.GetComponent<MonsterMovement>().Dumbdown();
            }

            // If the user is taking too long to find the book, shut off the lights and summon the monster.
            if (this.RecordTime >= SafetyPeriod && !this.MonsterTriggered)
            {
                this.TriggerMonster();
            }
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
