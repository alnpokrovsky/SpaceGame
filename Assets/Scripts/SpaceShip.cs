using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public float MotionSpeed = 1;
    public float Tilt = 1;
    public GameObject Сartridge;
    public Transform BigGun;

    private Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        UserUpdatePosition();
        UserShot();
    }

    private void UserUpdatePosition() {
        float xMove = Input.GetAxis("Horizontal");
        float yMove = Input.GetAxis("Vertical");
        body.velocity = new Vector3(xMove, yMove, 0) * MotionSpeed;
        body.rotation = Quaternion.Euler(yMove*Tilt, -xMove*Tilt, 0);
    }

    private void UserShot() {
        if (Input.GetButton("Fire1")) {
            Instantiate(Сartridge, BigGun.position, Quaternion.identity);
        }
    }
}
