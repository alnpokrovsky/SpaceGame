using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public float MinSpeed = 15;
    public float MaxSpeed = 30;
    public GameObject Explosion;

    private Rigidbody body;

    void Awake() {
        body = GetComponent<Rigidbody>();        
    }

    void Start()
    {
        float speed = Random.Range(MinSpeed, MaxSpeed);
        body.velocity = Vector3.down * speed;
        body.angularVelocity = Random.insideUnitSphere * speed * Random.value;
    }


    void OnTriggerEnter(Collider other) {
        if (other.tag == "GameBoundary") return;
        
        Instantiate(Explosion, transform.position, Quaternion.identity);

        Destroy(this.gameObject);
    }
}
