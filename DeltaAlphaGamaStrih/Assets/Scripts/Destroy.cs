using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    StartAndFinish sf;
    void Start()
    {
        sf = FindObjectOfType<StartAndFinish>();
    }

    void Update()
    {
        //if (sf.RoomsDestroy) { Destroy(this); }
        if (true) { Destroy(this); }
    }
}
