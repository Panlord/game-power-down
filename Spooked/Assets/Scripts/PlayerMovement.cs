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
    private Vector3 Velocity;
    private float JumpSpeed = 4.0f;
    private float Gravity = 20.0f;
    Vector3 move = Vector3.zero;



       void Start()
    {
        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        bool isRunning = Input.GetButton("Fire3");
        // Move the player based on what buttons were pressed.
        // W and S add 1 and -1 to the Vertical respectively.
        // A and D add -1 and 1 to the Horizontal respectively.
        float x = Input.GetAxis("Horizontal") * (isRunning ? RunningSpeed : WalkingSpeed);
        float z = Input.GetAxis("Vertical") * (isRunning ? RunningSpeed : WalkingSpeed);

        
        float movingY = move.y;
        move = transform.right * x + transform.forward * z;

        if (Input.GetButton("Jump") && Controller.isGrounded)
        {
            move.y = JumpSpeed;
        } else {
            move.y = movingY;
        }

        if (!Controller.isGrounded)
        {
            move.y -= Gravity * Time.deltaTime;
        }

        Controller.Move(move * Time.deltaTime);       

    }
}
