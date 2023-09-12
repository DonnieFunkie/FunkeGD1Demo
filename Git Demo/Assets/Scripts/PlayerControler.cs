/*** Donavan 9/12/2023 
Script For Basic Firstperson Chracter and Camera Controls


***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    //Player Variable
    public float speed = 2.0f;
    public float gravity = -10.0f;
    public float jumpForce = 2.0f;
    private CharacterController characterController;
    private Vector2 moveInput;
    private Vector3 playerPosition;
    private bool grounded;
    private Vector2 mouseMovement;

    //Camera Variables
    public Camera cameraLive;
    public float sensitivity = 25.0f;
    private float cam_x_rotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMove(InputAction.CallbackContext context)
    {

    }
    public void OnLook(InputAction.CallbackContext context)
    {

    }
    public void OnJump(InputAction.CallbackContext context)
    { 
   
    }
}
