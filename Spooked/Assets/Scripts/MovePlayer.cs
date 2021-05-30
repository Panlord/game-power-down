using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private CharacterController Controller;
    [SerializeField] private float Speed;
    Gamepad gamepad;
    Vector2 move;
    Vector2 move1;

    void Start()
    {
        gamepad = Gamepad.current;
    }

    void Update()
    {

        if (gamepad != null){
        float x = Gamepad.current.leftStick.x.ReadValue();
        float y = Gamepad.current.leftStick.y.ReadValue();

        Vector3 move = transform.right * x + transform.forward * y;
        Controller.Move(move * Speed * Time.deltaTime);
        }

        float x1 = Input.GetAxis("Horizontal");
        float z1 = Input.GetAxis("Vertical");
        Vector3 move1 = transform.right * x1 + transform.forward * z1;
        Controller.Move(move1 * Speed * Time.deltaTime);

    }
  
}
