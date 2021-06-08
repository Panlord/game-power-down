/* Coded by Aaron and Victor following Brackeys' FPS Controller tutorial on YouTube and 
https://gamedevacademy.org/unity-3d-first-and-third-person-view-tutorial/ and https://sharpcoderblog.com/blog/unity-3d-fps-controller */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class MouseLook : MonoBehaviour
{
    [SerializeField] 
    private float MouseSensitivity = 4.0f;
    [SerializeField] 
    private float JoystickSens = 4.0f;
    [SerializeField] 
    private Transform PlayerBody;
    Gamepad gamepad;
    private float minTurnAngle = -90.0f;
    private float maxTurnAngle = 90.0f;
    private float XRotation;
    private float y = 0.0f;

    void Start()
    {
        this.gamepad = Gamepad.current;
        // Hide and lock the cursor in the middle of the screen.
        // Cursor.lockState = CursorLockMode.None;
    }

     public void ResetView()
    {
        this.gameObject.transform.rotation = Quaternion.identity;
    }

    void Update()
    {
       MoveCamera();
    }

    void MoveCamera ()
    {
    if(gamepad != null){
    
    // Get joystick inputs.
    y =  Gamepad.current.rightStick.x.ReadValue() * JoystickSens * Time.deltaTime;
    XRotation += Gamepad.current.rightStick.y.ReadValue() * JoystickSens * Time.deltaTime;

    // C.lamp the vertical rotation.
    XRotation = Mathf.Clamp(XRotation, minTurnAngle, maxTurnAngle);
    // Rotate the camera.
    transform.eulerAngles = new Vector3(-XRotation, transform.eulerAngles.y + y, 0);
    transform.localRotation = Quaternion.Euler(-XRotation, 0f, 0f);
    PlayerBody.Rotate(Vector3.up * y);
    } 

    // Get the mouse inputs.
    y = Input.GetAxis("Mouse X") * MouseSensitivity;
    XRotation += Input.GetAxis("Mouse Y") * MouseSensitivity;

    // Clamp the camera.
    XRotation = Mathf.Clamp(XRotation, minTurnAngle, maxTurnAngle);

    // Rotate the camera.
    transform.eulerAngles = new Vector3(-XRotation, transform.eulerAngles.y + y, 0);
    transform.localRotation = Quaternion.Euler(-XRotation, 0f, 0f);
    PlayerBody.Rotate(Vector3.up * y);
    
    }
}
