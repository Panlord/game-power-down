using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Camera MainCamera;
    [SerializeField] private Camera MainMenuCamera;
    [SerializeField] private FlashLightController FlashLight;
    [SerializeField] private PlayerMovement PlayerMove;
    [SerializeField] private MouseLook FirstPerson;
    [SerializeField] private Inventory PlayerInventory;
    [SerializeField] private InteractiveItemManager ItemController;
    [SerializeField] private GameObject Monster;
    [SerializeField] private GameObject PlayerModel;
    [SerializeField] private GameObject HallwayLights;

    private GameObject[] Lights;
    [SerializeField] private GameObject InteractableObjects;
    [SerializeField] private GameObject Book;
    [SerializeField] private MonsterCollision MonsterCollider;
    [SerializeField] private MainMenuController MainMenu;
    [SerializeField] private IntroMenuController IntroMenu;
    [SerializeField] private PauseMenuController PauseMenu;
    [SerializeField] private EndMenuController EndMenu;
    [SerializeField] private LoreNotification ShowLore;
    [SerializeField] private InventoryMenuController InventoryMenu;

    private bool Paused;
    private bool HasBook;
    private bool MonsterTriggered;
    private bool InMenu;
    // Time recorded for storing in the leaderboard.
    private float RecordTime;

    public GameController() 
    {
        this.Paused = false;
        this.InMenu = true;
        this.RecordTime = 0.0f;
        this.HasBook = false;
        this.MonsterTriggered = false;
    }

    private void Start()
    {
        this.Lights = GameObject.FindGameObjectsWithTag("Light");
        this.SetWinningDoor();
        this.SetSpawn();
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
        for (int i = 0; i < 20; i++)
        {
            this.InteractableObjects.transform.GetChild(i).gameObject.SetActive(true);
        }
        this.Book.SetActive(true);
    }

    // Reset everything for another playthrough.
    // This should always be called upon returning to the main menu.
    private void Reset()
    {
        // FlashLight:
        this.FlashLight.TurnOff();

        // Timer:
        this.RecordTime = 0.0f;
        
        // Inventory:
        this.PlayerInventory.Reset();
        this.RespawnAll();

        // Player Position:
        this.SetSpawn();

        // Mouse Direction:
        this.FirstPerson.ResetView();

        // Hallway Lights and Book Possession:
        this.HasBook = false;
        
        // Lights:
        this.LightsOn();

        // Monster:
        this.Monster.SetActive(false);
        this.Monster.transform.position = new Vector3(1.535991f, -0.1799999f, -6.159369f);
        this.Monster.GetComponent<Animator>().enabled = false;
        this.Monster.GetComponent<MonsterMovement>().enabled = false;

        // Exits:
        GameObject.FindGameObjectsWithTag("ExitDoor")[0].tag = "Untagged";
        this.SetWinningDoor();

        // Misc:
        this.MonsterTriggered = false;
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
        this.InMenu = true;
    }

    // Pause or unpause the game.
    private void Pause()
    {
        // Pause game and monster.
        if (!this.Paused)
        {
            Debug.Log("Pause game");
            this.Monster.GetComponent<Animator>().enabled = false;
            this.Monster.GetComponent<MonsterMovement>().enabled = false;
            this.Monster.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            if (this.Monster.activeSelf)
            {
                this.Monster.GetComponent<MonsterMovement>().Halt();
            }   
        }
        // Unpause game and monster.
        else 
        {
            Debug.Log("Resume game");
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
        this.ItemController.enabled = this.Paused;
        this.Paused = !this.Paused;
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

    // Shut off the lights and summon the monster.
    private void TriggerMonster()
    {
        this.LightsOut();
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
            this.MainMenu.Deactivate();
            this.MainMenuCamera.gameObject.SetActive(false);
            this.MainCamera.gameObject.SetActive(true);
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

        // Was "Close" pressed when viewing a Lore you just got?
        if (this.ShowLore.IsActivated())
        {
            this.Pause();
            // Unpause the game and remove the lore from the screen.
            this.ShowLore.Deactivate();
            // If that lore piece was cursed (Monster POV), shut off lights and spawn monster.
            var inventory = this.PlayerInventory.GetInventory();
            if (inventory[inventory.Count - 1].IsCursed() && !this.MonsterTriggered)
            {
                Debug.Log("trigger mosnter via curse");
                this.TriggerMonster();
            }
        }

        // Pause the game.
        if (Input.GetKeyDown(KeyCode.Escape) && !this.InMenu)
        {
            if (!this.Paused)
            {   
                this.Pause();
                this.PauseMenu.Show();
            }
        }

        // Freeze the game (pause but dont show the menu).
        if (Input.GetKeyDown(KeyCode.R) && !this.InMenu)
        {
            this.Pause();
        }

        // Open / close inventory menu.
        if (Input.GetKeyDown(KeyCode.I) && !this.InMenu)
        {
            this.Pause();
            if (this.Paused)
            {
                this.InventoryMenu.Show();
            }
            else
            {
                this.InventoryMenu.Deactivate();
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
                    this.InMenu = true;
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
            this.PlayerInventory.ResetLore();
            this.Pause();
            var inventory = this.PlayerInventory.GetInventory();
            var obtainedLore = inventory[inventory.Count - 1];
            this.ShowLore.Set(obtainedLore);
            this.ShowLore.Show();
        }
        else if (this.PlayerInventory.GotBook())
        {
            if (!this.MonsterTriggered)
            {
                this.TriggerMonster();
            }
            this.HasBook = true;
            this.PlayerInventory.ResetBook();
        }

        if (!this.Paused) 
        {
            this.RecordTime += Time.deltaTime;
            Cursor.lockState = CursorLockMode.Locked;

            this.MonsterCollider.gameObject.transform.position = this.PlayerModel.transform.position;

            if (this.MonsterCollider.Hit())
            {
                this.Pause();
                this.MonsterCollider.Reset();
                this.InMenu = true;
                this.EndMenu.Show(false, this.RecordTime);
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
            if (this.RecordTime >= 60 && !this.MonsterTriggered)
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