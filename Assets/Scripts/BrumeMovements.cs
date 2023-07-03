using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrumeMovements : MonoBehaviour
{
    public float charMovingSpeed = 5.0f;
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    Vector2 charDirection;
    int directionValue = 0; // Idle = 0, Side = 1, Bas = 2, Haut = 3

    // Update is called once per frame
    void Update()
    {
        HandleKeys();
        GenerateMovement();
    }

    public void HandleKeys()
    {
         if (Input.GetKey(KeyCode.UpArrow)) 
        {
            charDirection = Vector2.up;
            directionValue = 3;
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            charDirection = Vector2.right;
            directionValue = 1;
            spriteRenderer.flipX = true;
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            charDirection = Vector2.down;
            directionValue = 2;
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            charDirection = Vector2.left;
            directionValue = 1;
            spriteRenderer.flipX = false;
        }

        else
        {
            charDirection = Vector2.zero;
        }
    }

    public void GenerateMovement()
    {
        rb.MovePosition(rb.position + charDirection * charMovingSpeed * Time.fixedDeltaTime);
        animator.SetInteger("direction", directionValue);
    }
}
