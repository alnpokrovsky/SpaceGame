using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerShot : MonoBehaviour
{
    public float Speed = 30;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        body.velocity = transform.up * Speed;
    }


    void OnTriggerEnter(Collider other) {
        if (other.tag == "GameBoundary") return;
        
        if (tag != other.tag) {
            Destroy(this.gameObject);
        }
    }
}
