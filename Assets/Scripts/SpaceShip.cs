using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public float ZAngle = 45;
    public float MotionSpeed = 1;
    public float Tilt = 1;
    public GameObject MainСartridge;
    public Transform MainGun;
    public float ReloadMainGunTimeout = 1;
    
    public GameObject ExtraСartridge;
    public Transform ExtraGun1;
    public Transform ExtraGun2;
    public float ReloadExtraGunTimeout = 2;


    private Rigidbody body;
    private SphereCollider sphere;
    private Reloader reloaderMain;
    private Reloader reloaderExtra;
    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        sphere = GetComponent<SphereCollider>();
        reloaderMain = new Reloader(ReloadMainGunTimeout);
        reloaderExtra = new Reloader(ReloadExtraGunTimeout);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShootMainGun() {
        if (reloaderMain.Ready) {
            reloaderMain.Shot();
            Instantiate(MainСartridge, MainGun.position, QZRotation(0));
        }
    }

    public void ShootExtraGun() {
        if (reloaderExtra.Ready) {
            reloaderExtra.Shot();
            Instantiate(ExtraСartridge, ExtraGun1.position, QZRotation(+45));
            Instantiate(ExtraСartridge, ExtraGun2.position, QZRotation(-45));
        }
    }

    public void Move(float xMove, float yMove, BoxCollider boundary = null) {
        body.velocity = QZRotation(0) * new Vector3(xMove, yMove, 0) * MotionSpeed;
        body.rotation = QZRotation(0) * Quaternion.Euler(yMove*Tilt, -xMove*Tilt, 0);
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

    private Quaternion QZRotation(float z) {
        return Quaternion.Euler(0,0, ZAngle + z);
    }

}
