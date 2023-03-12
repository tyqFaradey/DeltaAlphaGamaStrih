using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public int d = 0;
    void Start()
    {

    }

    void Update()
    {

        Invoke("D", 1);
    }

    void D()
    {
        d++;
    }
}
