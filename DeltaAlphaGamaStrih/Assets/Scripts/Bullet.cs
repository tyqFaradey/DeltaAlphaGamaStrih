using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;

    public float damage = 3;

    void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 5);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall" || collision.tag == "Box") { Destroy(gameObject); }
        if (collision.tag == "Enemy")
        {
            //GameObject arrow = GameObject.Find("arrowPrefab");
            //arrow.transform.rotation = Quaternion.Euler(0, 10, 180);
            var enemy = collision.GetComponent<EnemyHealth>();
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
