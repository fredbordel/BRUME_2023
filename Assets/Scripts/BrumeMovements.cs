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
    [SerializeField]
    private Animator brumeAnimator;
    private Animator chienAnimator;

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
        brumeAnimator = GetComponent<Animator>();
        chienAnimator = GameObject.FindGameObjectsWithTag("chien")[0].GetComponent<Animator>();

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

    void Update()
    {

        if (!MainManager.Instance || (MainManager.Instance && !MainManager.Instance.IsDialogueOpened))
        {

            moveInput = playerActions.Brume.Movement.ReadValue<Vector2>();

            if (moveInput.y < 0)
            {
                brumeAnimator.SetInteger("direction", 1);
                chienAnimator.SetInteger("direction", 0);
            }

            else if (moveInput.x > 0 || moveInput.x < 0)
            {
                brumeAnimator.SetInteger("direction", 2);
                chienAnimator.SetInteger("direction", 1);
            }

            else if (moveInput.y > 0)
            {
                brumeAnimator.SetInteger("direction", 3);
                chienAnimator.SetInteger("direction", 2);
            }

            rbody.velocity = moveInput * speed;
        }
        else
        {
            rbody.velocity = Vector2.zero;
        }
    }
}
