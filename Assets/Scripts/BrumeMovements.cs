using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrumeMovements : MonoBehaviour
{

    // Variables

    public float charMovingSpeed = 5.0f;
    public Rigidbody2D rb;
    Vector2 charDirection;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) 
        {
            charDirection = Vector2.up;
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            charDirection = Vector2.right;
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            charDirection = Vector2.down;
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            charDirection = Vector2.left;
        }

        else
        {

            Debug.Log("HEllo");
            charDirection = Vector2.zero;
        }

        rb.MovePosition(rb.position + charDirection * charMovingSpeed * Time.fixedDeltaTime);
    }
}
