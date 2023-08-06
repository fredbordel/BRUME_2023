using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BrumeMovements : MonoBehaviour
{

    [SerializeField]
    private float speed;
    [SerializeField]
    private Rigidbody2D rbody;
    private PlayerInputActions playerActions;
    private Vector2 moveInput;

    void Awake()
    {
        playerActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        playerActions.Brume.Enable();
    }

    private void OnDisable()
    {
        playerActions.Brume.Disable();
    }

    void FixedUpdate()
    {
        moveInput = playerActions.Brume.Movement.ReadValue<Vector2>();
        rbody.velocity = moveInput * speed;

        playerActions.Brume.Movement.performed += Try;
        
    }

    private void Try(InputAction.CallbackContext context)
    {
        Debug.Log("SUBSCRIBE " + context.ReadValue<Vector2>());
    }

    void Update()
    {
        if (moveInput.y > 0) 
        {
            Debug.Log("GOING UP");
        }

        if (moveInput.y < 0) 
        {
            Debug.Log("GOING DOWN");
        }
    }


    // public float charMovingSpeed = 5.0f;
    // public Rigidbody2D rb;
    // public Animator animator;
    // public SpriteRenderer spriteRenderer;
    // Vector2 charDirection;
    // int directionValue = 0; // Idle = 0, Side = 1, Bas = 2, Haut = 3


    // [SerializeField]
    // private InputActionReference movement;
    // private Vector2 movementInput;

    // void Update()
    // {
    //     movementInput = movement.action.ReadValue<Vector2>();
    //     HandleKeys();
    //     GenerateMovement();
    // }

    // private void OnEnable()
    // {
    //     movement.action.performed += LogIt;
    // }

    // private void LogIt(InputAction.CallbackContext obj)
    // {
    //     Debug.Log("ACTION PERFORMED" + obj);
    // }

    // public void HandleKeys()
    // {
    //      if (Input.GetKey(KeyCode.UpArrow)) 
    //     {
    //         charDirection = Vector2.up;
    //         directionValue = 3;
    //     }

    //     else if (Input.GetKey(KeyCode.RightArrow) )
    //     {
    //         charDirection = Vector2.right;
    //         directionValue = 1;
    //         spriteRenderer.flipX = true;
    //     }

    //     else if (Input.GetKey(KeyCode.DownArrow))
    //     {
    //         charDirection = Vector2.down;
    //         directionValue = 2;
    //     }

    //     else if (Input.GetKey(KeyCode.LeftArrow))
    //     {
    //         charDirection = Vector2.left;
    //         directionValue = 1;
    //         spriteRenderer.flipX = false;
    //     }

    //     else
    //     {
    //         charDirection = Vector2.zero;
    //     }
    // }

    // public void GenerateMovement()
    // {
    //     rb.MovePosition(rb.position + charDirection * charMovingSpeed * Time.fixedDeltaTime);
    //     animator.SetInteger("direction", directionValue);
    // }
}
