using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float MinSpeed = 15;
    public float MaxSpeed = 30;
    public GameObject Explosion;

    private Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        float speed = Random.Range(MinSpeed, MaxSpeed);
        body.velocity = Vector3.down * speed;
        body.angularVelocity = Random.insideUnitSphere * speed;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "GameBoundary") return;
        
        Instantiate(Explosion, transform.position, Quaternion.identity);

        Destroy(this.gameObject);
    }
}
