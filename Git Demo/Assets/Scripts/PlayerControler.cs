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
    private Vector3 playerVelocity;
    private bool grounded;
    private Vector2 mouseMovement;

    //Camera Variables
    public Camera cameraLive;
    public float sensitivity = 25.0f;
    private float cam_x_rotation;

    // Start is called before the first frame update
    void Start()
    {
        
        characterController = GetComponent<CharacterController>();

        //Hides the mouse cursir at start
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        grounded = characterController.isGrounded;
        MovePlayer();

    }

    public void MovePlayer()
    {
        //Direction is Move
        Vector3 moveVec = transform.right * moveInput.x + transform.forward * moveInput.y;

        //Move Controller
        characterController.Move(moveVec * speed * Time.deltaTime);

        playerVelocity.y += gravity * Time.deltaTime;

        if (grounded && playerVelocity.y < 0) 
            {
                playerVelocity.y = -2.5f;
        
            }
        characterController.Move(playerVelocity * Time.deltaTime);
    }

    public void Look() 
    { 
        float xAmount = mouseMovement.x * sensitivity * Time.deltaTime;
        float yAmount = mouseMovement.y * sensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseMovement * sensitivity * Time.deltaTime);

        cam_x_rotation -= xAmount;
        cam_x_rotation = Mathf.Clamp(cam_x_rotation, -90f, 90f);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        Debug.Log("Move Input Value" + moveInput.ToString());

    }
    public void OnLook(InputAction.CallbackContext context)
    {
        mouseMovement = context.ReadValue<Vector2>();
        Debug.Log("Mouse Movement Value" + mouseMovement.ToString());
    }
    public void OnJump(InputAction.CallbackContext context)
    {

        Jump();
        Debug.Log("Jump Input Value" + moveInput.ToString());
    }

    public void Jump()
    {
        if (grounded)
        {
            playerVelocity.y = jumpForce;
        }
    }

}
