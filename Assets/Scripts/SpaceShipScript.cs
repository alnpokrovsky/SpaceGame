﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipScript : MonoBehaviour
{
    public float MotionSpeed = 1;
    public float Tilt = 1;
    public GameObject MainСartridge;
    public Transform MainGun;
    public float ReloadMainGunTimeout = 1;
    
    public GameObject ExtraСartridge;
    public Transform ExtraGun1;
    public Transform ExtraGun2;
    public float ReloadExtraGunTimeout = 2;

    public GameObject Explosion;

    private Rigidbody body;
    private Bounds shipBounds;
    private Reloader reloaderMain;
    private Reloader reloaderExtra;
    private float zAngle;
    
    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody>();
        reloaderMain = new Reloader(ReloadMainGunTimeout);
        reloaderExtra = new Reloader(ReloadExtraGunTimeout);
    }

    void Start() {
        zAngle = transform.rotation.eulerAngles.z;
        shipBounds = ContentBounds.Box(this.gameObject).Value;
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "GameBoundary") return;
        
        if (other.tag != tag) {
            Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    public void ShootMainGun() {
        if (reloaderMain.Ready) {
            reloaderMain.Shot();
            Instantiate(MainСartridge, MainGun.position, QZRotation(0))
            .tag = tag;
        }
    }

    public void ShootExtraGun() {
        if (reloaderExtra.Ready) {
            reloaderExtra.Shot();
            Instantiate(ExtraСartridge, ExtraGun1.position, QZRotation(+45))
            .tag = tag;
            Instantiate(ExtraСartridge, ExtraGun2.position, QZRotation(-45))
            .tag = tag;
        }
    }

    public void Move(float xMove, float yMove, BoxCollider gameBoundary = null) {
        body.velocity = QZRotation() * new Vector3(xMove, yMove, 0) * MotionSpeed;
        body.rotation = QZRotation() * Quaternion.Euler(yMove*Tilt, -xMove*Tilt, 0);
        if (gameBoundary != null) {
            Vector3 center = gameBoundary.center - gameBoundary.center;
            Vector3 size = gameBoundary.size - shipBounds.size;
            float xPos = Mathf.Clamp(body.position.x,
                                center.x - size.x/2,
                                center.x + size.x/2);
            float yPos = Mathf.Clamp(body.position.y, 
                                center.y - size.y/2,
                                center.y + size.y/2);
            body.position = new Vector3(xPos, yPos, body.position.z);
        }
    }

    private Quaternion QZRotation(float z = 0) {
        return Quaternion.Euler(0,0, zAngle + z);
    }

}
