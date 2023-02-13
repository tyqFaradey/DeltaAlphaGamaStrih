using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public int speed;
    public int flipSpeed;
    

    private int sped;

    private float moveInputH;
    private float moveInputV;
    private float flipInput;

    private KBGPController controls;

    private void Awake()
    {
        controls = new KBGPController();

        // Jump
        //controls.Main.Flip.performed += context => Flip();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Start()
    {
        sped = speed;
    }

    void Update()
    {
        Movement0();

        Flip();

        Debug.Log(flipInput);
    }

    private void Movement0()
    {
        moveInputH = controls.Main.MoveH.ReadValue<float>();
        moveInputV = controls.Main.MoveV.ReadValue<float>();


        if (moveInputV > 0) // W
        {
            rb.velocity = new Vector2(rb.velocity.x, moveInputV * speed / 10);   
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

    private void Flip()
    {
        flipInput = controls.Main.Flip.ReadValue<float>();

        if (flipInput == 1)
        {
            rb.AddForce(rb.velocity * flipSpeed / 10);
        }
    }
}
