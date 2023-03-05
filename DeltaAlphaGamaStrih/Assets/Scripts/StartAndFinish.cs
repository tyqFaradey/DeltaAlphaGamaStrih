using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAndFinish : MonoBehaviour
{
    public bool RoomsDestroy = true;
    RoomGeneration rg;
    void Start()
    {
        rg = FindObjectOfType<RoomGeneration>();
    }

    void Update()
    {
        //OnCollisionEnter2D();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Finish"))
        {
           //RoomsDestroy = true;
           // rg.StartNewLevel = true;
        }
    }
}
