using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public float MotionSpeed = 1;
    public float Tilt = 1;
    public GameObject Сartridge;
    public Transform MainGun;

    public float ReloadMainGunTimeout = 1;

    private Rigidbody body;
    private SphereCollider sphere;
    private float reloadMainGunTime;
    private bool ReloadMainGun {
        get { return Time.time < reloadMainGunTime; }
        set { 
            if (value == true) {
                reloadMainGunTime = Time.time + ReloadMainGunTimeout;
            }
        }
    }

    public void ShotMainGun() {
        if (!ReloadMainGun) {
            ReloadMainGun = true;
            Instantiate(Сartridge, MainGun.position, body.rotation);
        }
    }
    public void Move(float xMove, float yMove, BoxCollider boundary = null) {
        body.velocity = new Vector3(xMove, yMove, 0) * MotionSpeed;
        body.rotation = Quaternion.Euler(yMove*Tilt, -xMove*Tilt, 0);
        if (boundary != null) {
            Vector3 center = boundary.center - sphere.center;
            float xPos = Mathf.Clamp(body.position.x,
                                center.x - (boundary.size.x/2-sphere.radius),
                                center.x + (boundary.size.x/2-sphere.radius));
            float yPos = Mathf.Clamp(body.position.y, 
                                center.y - (boundary.size.y/2-sphere.radius),
                                center.y + (boundary.size.y/2-sphere.radius));
            body.position = new Vector3(xPos, yPos, body.position.z);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        sphere = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
