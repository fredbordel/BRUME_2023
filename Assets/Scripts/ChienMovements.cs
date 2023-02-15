using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChienMovements : MonoBehaviour
{

    public float speed;
    public Collider2D brumeCollider;
    public Collider2D chienCollider;
    private Transform brume;

    private void Start()
    {
        brume = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

     private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, brume.position, speed * Time.deltaTime);
        Physics2D.IgnoreCollision(brumeCollider, chienCollider, true);
    }
    //private Rigidbody2D rb;
    //private Player brume;
    //private float speed;
    //private Vector3 directionToBrume;
    //private Vector3 localScale;

    //void Start()
    //{
    //    rb = GetComponent<Rigidbody2D>();
    //    brume = FindObjectOfType(typeof(Player)) as Player;
    //    speed = 3;
    //    localScale = transform.localScale;
    //}

    //private void FixedUpdate()
    //{
    //    if(Vector3.Distance(transform.position, brume.transform.position) > 0.3)
    //    {
    //        MoveChien();
    //    }
    //}

    //private void MoveChien()
    //{
    //    directionToBrume = (brume.transform.position - transform.position * 2).normalized;
    //    rb.velocity = new Vector2(directionToBrume.x, directionToBrume.y) * speed;
    //}
}
