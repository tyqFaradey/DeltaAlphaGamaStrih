using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAndFinish : MonoBehaviour
{
    public bool RoomsDestroy = false;
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
            foreach (var room in GameObject.FindGameObjectsWithTag("Room"))
            {
                Destroy(room);
            }
            foreach (var enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                Destroy(enemy);
            }
            rg.StartNewLevel = true;
        }
    }
}
