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
        if (sf.RoomsDestroy) { Destroy(gameObject); print(1); }
    }
}
