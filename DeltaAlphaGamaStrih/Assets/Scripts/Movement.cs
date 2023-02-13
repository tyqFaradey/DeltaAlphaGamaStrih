using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public int speed;
    public int flipSpeed;

    private float moveInputH;
    private float moveInputV;

    private KBGPController controls;

    private void Awake()
    {
        controls = new KBGPController();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }


    void Update()
    {
        Movement0();
    }

    private void Movement0()
    {
        moveInputH = controls.Main.MoveH.ReadValue<float>();
        moveInputV = controls.Main.MoveV.ReadValue<float>();

        if (moveInputV > 0) // W
        {
            rb.velocity = new Vector2(rb.velocity.x, moveInputV * speed / 10);
            if (Input.GetKeyDown(KeyCode.Space)) {
                rb.velocity = new Vector2(rb.velocity.x, flipSpeed);
            }
        }

        if (moveInputV < 0) // S
        {

            rb.velocity = new Vector2(rb.velocity.x, moveInputV * speed / 10);
        }

        if (moveInputH > 0) // D
        {
            rb.velocity = new Vector2(moveInputH * speed / 10, rb.velocity.y);
        }

        if (moveInputH < 0) // A
        {
            rb.velocity = new Vector2(moveInputH * speed / 10, rb.velocity.y);
        }

    }
}
