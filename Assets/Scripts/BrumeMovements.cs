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

    void Start()
    {
        if (MainManager.Instance.BrumePosition != null)
        {
            gameObject.transform.position = MainManager.Instance.BrumePosition;
        }
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

        if(!MainManager.Instance.IsDialogueOpened)
        {
            
            moveInput = playerActions.Brume.Movement.ReadValue<Vector2>();
            playerActions.Brume.Movement.performed += Try;
            rbody.velocity = moveInput * speed;
        } 
        
        else
        {
            rbody.velocity = Vector2.zero;
        }

        
    }

    private void Try(InputAction.CallbackContext context)
    {
        // Debug.Log("SUBSCRIBE " + context.ReadValue<Vector2>());
    }
}
