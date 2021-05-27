// Created by Aaron, following Brackeys' FPS Controller tutorial on YouTube.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController Controller;

    // Player character's movement speed.
    [SerializeField] private float Speed;
    public float Gravity = -9.81f;
    private Vector3 Velocity;

    // Checking if the player is touching the ground.
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private float GroundDistance = 0.4f;
    [SerializeField] private LayerMask GroundMask;
    private bool IsOnGround;

    void Update()
    {
        // Check if the player is on the ground.
        this.IsOnGround = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);
        if (IsOnGround && Velocity.y < 0)
        {
            Velocity.y = -2f;
        }

        // Move the player based on what buttons were pressed.
        // W and S add 1 and -1 to the Vertical respectively.
        // A and D add -1 and 1 to the Horizontal respectively.
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;

        Controller.Move(move * Speed * Time.deltaTime);

        // Apply gravity.
        this.Velocity.y += Gravity * Time.deltaTime;
        Controller.Move(Velocity * Time.deltaTime);
    }
}
