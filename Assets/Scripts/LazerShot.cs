using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerShot : MonoBehaviour
{
    public float Speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        body.velocity = body.rotation * Vector3.up * Speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
