// Created by Aaron && Victor following Brackeys' FPS Controller tutorial on YouTube and with https://sharpcoderblog.com/blog/unity-3d-fps-controller

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] 
    private CharacterController Controller;
    [SerializeField] 
    private float RunningSpeed = 11.5f;
    [SerializeField]
    private float WalkingSpeed = 7.5f;
    private float HalfSpeed = 3.25f;
    private Vector3 Velocity;
    private float Gravity = 20.0f;
    Vector3 move = Vector3.zero;
    [SerializeField] private float timeRan = 0f;
    private bool Exhausted = false;
    public AudioClip TiredClip;
    AudioSource Audio;

    void Start()
    {
        // Lock cursor
        // Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;
        Audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        bool isRunning = false;
        if (timeRan >= 1.5f)
        {
            Exhausted = true;
            Audio.PlayOneShot(TiredClip, 0.35f);
        }
        
        if (timeRan <= 0)
        {
            timeRan = 0;
            Exhausted = false;
        }

        if (Input.GetButton("Fire3") && !Exhausted)
        {
            isRunning = true;
        }

        if (timeRan < 3 && !isRunning || Exhausted)
        {
            timeRan -= Time.deltaTime;
        }
        else if (!Exhausted && isRunning)
        {
            timeRan += Time.deltaTime;
        }

        // Move the player based on what buttons were pressed.
        // W and S add 1 and -1 to the Vertical respectively.
        // A and D add -1 and 1 to the Horizontal respectively.
        float x = Input.GetAxis("Horizontal") * (Exhausted ? HalfSpeed : isRunning ? RunningSpeed : WalkingSpeed);
        float z = Input.GetAxis("Vertical") * (Exhausted ? HalfSpeed : isRunning ? RunningSpeed : WalkingSpeed);

        
        float movingY = move.y;
        move = transform.right * x + transform.forward * z;

        if (!Controller.isGrounded)
        {
            move.y -= Gravity * Time.deltaTime;
        }

        Controller.Move(move * Time.deltaTime);       

    }
}