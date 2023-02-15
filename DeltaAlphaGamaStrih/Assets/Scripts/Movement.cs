using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;
using static Unity.VisualScripting.Member;
//using System.Collections;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform rot;
    public int speed;
    public int flipSpeed;

    float smooth = 5.0f;
    float tiltAngle = 60.0f;

    float tiltAroundZ;
    float tiltAroundX;

    float animValue;

    public Joystick joystick;
    private Vector2 moveVelocity;



    float moveInputH;
    float moveInputV;
    float flipInput;

    KBGPController controls;

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

    void Start()
    {
        
    }

    void Update()
    {
        moveInputH = controls.Main.MoveH.ReadValue<float>();
        moveInputV = controls.Main.MoveV.ReadValue<float>();

        tiltAroundZ = moveInputH;
        tiltAroundX = -moveInputV;

        Movement0();

        Flip();

        Quaternion target = Quaternion.Euler(tiltAroundX, tiltAroundZ, 0);

        rot.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);

        //Vector2 moveInput = new Vector2(moveInputH, moveInputV);
        //moveVelocity = moveInput.normalized * speed;

        //rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);

        Debug.Log(tiltAroundZ + "H");
        //Debug.Log(tiltAroundX + "V");
    }

    private void Movement0()
    {
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


    //tiltAroundZ H
    //tiltAroundX V

    private void AnimationRotation()
    { 
        if (tiltAroundZ == 0 & tiltAroundX == 0)
        {
            animValue = 0;
        }

        if (tiltAroundZ == 0 & tiltAroundX == 60)
        {
            animValue = 0;
        }
    }

    


}
