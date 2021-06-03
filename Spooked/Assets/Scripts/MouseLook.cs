// Coded by Aaron, following Brackeys' FPS Controller tutorial on YouTube.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float MouseSensitivity = 100f;

    [SerializeField] private Transform PlayerBody;

    // Rotation of the player's body in the horizontal direction.
    float XRotation = 0f;

    void Update()
    {
        // When the mouse moves side to side, the camera (and character) move side to side.
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
