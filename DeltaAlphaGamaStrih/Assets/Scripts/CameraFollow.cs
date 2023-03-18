using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float speed;
    public Transform target;
    public new Transform camera;

    void Start()
    {
        
    }
    
    void FixedUpdate()
    {
        var pos = Vector2.Lerp(transform.position, target.position, 0.0001f);
        camera.transform.position = new Vector3(pos.x, pos.y, -10);
    }

    private void follow()
    {
        
    }
}
