using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordFollow : MonoBehaviour
{
    public float speed;
    public Transform target;
    public new Transform sword;

    void Start()
    {

    }

    void FixedUpdate()
    {
        var pos = Vector2.Lerp(transform.position, target.position, speed);
        sword.transform.position = new Vector3(pos.x, pos.y, 1);
    }

    private void follow()
    {

    }
}
