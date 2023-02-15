using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;
using static Unity.VisualScripting.Member;
using UnityEditor;
//using System.Collections;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform rot;
    public int speed;
    public int flipSpeed;

    float animValue;

    float moveInputH;
    float moveInputV;
    float flipInput;

    float angle;

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

        Movement0();

        Flip();

        AnimationRotation();

        Debug.Log(animValue);
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
    private void AnimationRotation()
    {
        angle = Mathf.Asin(moveInputV) / (Mathf.PI / 180);

        //Debug.Log(angle);

        if (moveInputH == 0 & moveInputV == 0)
        {
            animValue = 0;
            //Debug.Log("0");
        }

        if (moveInputH > 0)
        {
            if (angle > -22.5 & angle < 22.5) { animValue = 1; }
            if (angle > 22.5 & angle < 67.5) { animValue = 2; }
            if (angle > 67.5 & angle < 90) { animValue = 3; }
            if (angle > -67.5 & angle < -22.5) { animValue = 8; }
            if (angle >= -90 & angle < -67.5) { animValue = 7; }
        }

        if (moveInputH < 0)
        {
            if (angle > -22.5 & angle < 22.5) { animValue = 5; }
            if (angle > 22.5 & angle < 67.5) { animValue = 4; }
            if (angle > 67.5 & angle < 90) { animValue = 3; }
            if (angle > -67.5 & angle < -22.5) { animValue = 6; }
            if (angle > -90 & angle < -67.5) { animValue = 7; }
        }

        if (angle == 90) { animValue = 3; }
        if (angle == -90) { animValue = 7; }
    }

    /*

        if (moveInputH == 0 & moveInputV > 0)
        {
            animValue = 1;
            Debug.Log("Up");
        }

        if (moveInputH == 0 & moveInputV < 0)
        {
            animValue = -1;
            Debug.Log("Down");
        }


        if (moveInputH > 0 & moveInputV == 0)
        {
            animValue = 2;
            Debug.Log("Right");
        }

        if (moveInputH < 0 & moveInputV == 0)
        {
            animValue = -2;
            Debug.Log("Left");
        }
        */


}
