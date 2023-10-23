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

    void Start()
    {
        var MainManagerInstance = MainManager.Instance;
        if (MainManagerInstance && MainManagerInstance.BrumePosition != null && MainManagerInstance.CurrentScene == "nouvelle_map")
        {
            gameObject.transform.position = MainManagerInstance.BrumePosition;
        }
    }

    private void OnDisable()
    {
        playerActions.Brume.Disable();
    }

    void FixedUpdate()
    {

        if (!MainManager.Instance || (MainManager.Instance && !MainManager.Instance.IsDialogueOpened))
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
