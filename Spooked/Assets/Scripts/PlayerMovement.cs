// Created by Aaron, following Brackeys' FPS Controller tutorial on YouTube.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController Controller;

    // Player character's movement speed.
    [SerializeField] private float Speed;

    void Update()
    {
        // Move the player based on what buttons were pressed.
        // W and S add 1 and -1 to the Vertical respectively.
        // A and D add -1 and 1 to the Horizontal respectively.
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;

        Controller.Move(move * Speed * Time.deltaTime);
    }
}
