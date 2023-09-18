using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChienMovements : MonoBehaviour
{

    public float speed;
    public Collider2D brumeCollider;
    public Collider2D chienCollider;
    private Transform brume;
    //public Rigidbody2D rb;
    public static ChienMovements Instance;

 void Awake()
    {
         if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        brume = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


     private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, brume.position, speed * Time.deltaTime);
        //triggerChienFollow();
        Physics2D.IgnoreCollision(brumeCollider, chienCollider, true);
    }

    private void triggerChienFollow()
    {
        //var directionToPlayer = (brume.transform.position - transform.position).normalized;
        //rb.MovePosition(brume.transform.position);
        //rb.velocity = new Vector2(directionToPlayer.x, directionToPlayer.y) * speed;
    }
}
