// Coded by Aaron, following Brackeys' FPS Controller tutorial on YouTube.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class MouseLook : MonoBehaviour
{
    [SerializeField] public float MouseSensitivity = 100f;
    [SerializeField] private Transform PlayerBody;
    Gamepad gamepad;


    // Rotation of the player's body in the horizontal direction.
    float XRotation = 0f;

    void Start()
    {
        gamepad = Gamepad.current;
        // Hide and lock the cursor in the middle of the screen.
        Cursor.lockState = CursorLockMode.Locked;
    
    }

    void Update()
    {
        
        if(gamepad != null){
         // When the mouse moves side to side, the camera (and character) move side to side.
        float moveX = Gamepad.current.rightStick.x.ReadValue() * MouseSensitivity * Time.deltaTime;
        // Same for when the mouse moves up and down.
        float moveY = Gamepad.current.rightStick.y.ReadValue() * MouseSensitivity * Time.deltaTime;
        // Stop the player from being an owl and rotating their head/camera 180+ degrees,
        // i.e. clamp the camera.
        this.XRotation -= moveY;
        this.XRotation = Mathf.Clamp(XRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(XRotation, 0f, 0f);
        // Rotate the player from side-to-side when moving the camera side-to-side.
        PlayerBody.Rotate(Vector3.up * moveX);
        }
        
        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        // Same for when the mouse moves up and down.
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;
        // Stop the player from being an owl and rotating their head/camera 180+ degrees,
        // i.e. clamp the camera.
        this.XRotation -= mouseY;
        this.XRotation = Mathf.Clamp(XRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(XRotation, 0f, 0f);
        // Rotate the player from side-to-side when moving the camera side-to-side.
        PlayerBody.Rotate(Vector3.up * mouseX);

    }
}
