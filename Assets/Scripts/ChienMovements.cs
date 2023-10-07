using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChienMovements : MonoBehaviour
{

    public float speed = 5;
    public Collider2D brumeCollider;
    public Collider2D chienCollider;
    private Transform brume;
    private Rigidbody2D rb;

    private float distance;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        brume = GameObject.FindGameObjectWithTag("brume").GetComponent<Transform>();

        if (MainManager.Instance.ChienPosition != null)
        {
            gameObject.transform.position = MainManager.Instance.ChienPosition;
        }
    }


    private void Update()
    {
        Physics2D.IgnoreCollision(brumeCollider, chienCollider, true);

        if (Vector2.Distance(transform.position, brume.position) > 1.2)
        {
            transform.position = Vector2.MoveTowards(transform.position, brume.position, speed * Time.deltaTime);
        }
    }
}
