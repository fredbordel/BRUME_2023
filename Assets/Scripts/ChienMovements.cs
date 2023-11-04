using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChienMovements : MonoBehaviour
{

    public float speed = 5;
    public Collider2D brumeCollider;
    public Collider2D chienCollider;
    public float chienDistanceFromBrume;
    private Transform brume;
    private Rigidbody2D rb;

    private float distance;
    private bool canChienMove;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        brume = GameObject.FindGameObjectWithTag("brume").GetComponent<Transform>();

        var MainManagerInstance = MainManager.Instance;
        if (MainManagerInstance && MainManagerInstance.ChienPosition != null && MainManagerInstance.CurrentScene == "nouvelle_map")
        {
            gameObject.transform.position = MainManagerInstance.ChienPosition;
        }
    }


    private void Update()
    {
        // Physics2D.IgnoreCollision(brumeCollider, chienCollider, true);
        if (Vector2.Distance(transform.position, brume.position) > chienDistanceFromBrume)
        {
            transform.position = Vector2.MoveTowards(transform.position, brume.position, speed * Time.deltaTime);
        }
    }
}
