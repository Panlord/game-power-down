// Authors: Erik, Peter.
// Menu functionality + GameController support - Erik. Scrolling Menu - Peter.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour 
{
    [SerializeField] private Button StartButton;
    [SerializeField] private Button ExitButton;
    [SerializeField] private Camera MainMenuCamera;

    private float CameraSpeed;
    private float TimeMove;
    private float MaxTimeMove;
    private bool Activated;

    private MainMenuController()
    {
         this.Activated = false;
        this.CameraSpeed = 0.5f;
    }

    void Awake()
    {
        this.ResetPosition();
        this.TimeMove = 0.0f;
        this.MaxTimeMove = 50.0f;
        this.StartButton.onClick.AddListener(Activate);
        this.ExitButton.onClick.AddListener(Application.Quit);
    }

    void Update()
    {
        this.TimeMove += Time.deltaTime;
        if (this.TimeMove > this.MaxTimeMove)
        {
            this.ResetPosition();
            this.TimeMove = 0.0f;
        }
        this.MainMenuCamera.transform.localPosition += new Vector3(this.CameraSpeed * Time.deltaTime, 0, 0);

        if (Input.GetButtonDown("Use"))
        {
            Activate();
        }
    }

    public void ResetPosition()
    {
        this.MainMenuCamera.transform.localPosition = new Vector3(-16.0f, 1.3f, -8.35f);
    }

    public bool IsActivated()
    {
        return this.Activated;
    }

    public void Activate() 
    {
        this.Activated = true;
    }

    public void Deactivate()
    {
        this.Activated = false;
        this.gameObject.SetActive(false);
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    
}