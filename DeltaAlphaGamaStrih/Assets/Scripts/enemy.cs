using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float seeDistance = 10;

    public float speed;
    private Transform target;
    private bool canMove;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;        
    }

    void FixedUpdate()
    {
        CheckDistance();
        Move();
    }

    void Move()
    {


        if (!canMove)
        {
            return;
        }

        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * speed;
    }

    void CheckDistance()
    {
        canMove = Vector2.Distance(transform.position, target.position) <= seeDistance;
    }
}
