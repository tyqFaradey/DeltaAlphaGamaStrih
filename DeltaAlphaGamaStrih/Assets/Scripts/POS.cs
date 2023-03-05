using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POS : MonoBehaviour
{
    public float x, y;
    public bool o;
    public bool change = false;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (change)
        {
            change = false;
            transform.position = new Vector2(x, y);
        }
        if (o) { transform.position = new Vector2(0, 0); o = false; }
    }
}
