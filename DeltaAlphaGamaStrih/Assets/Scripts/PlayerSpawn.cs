using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public bool kira = true;
    POS xy;
    void Start()
    {
        xy = FindObjectOfType<POS>();
    }

    void Update()
    {
        if (kira)
        {
            kira = false;
            xy.x = transform.position.x;
            xy.y = transform.position.y;
            xy.change = true;
        }
    }
}
