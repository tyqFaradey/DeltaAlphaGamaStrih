using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public bool kira = true;

    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = transform.position;
    }
}
