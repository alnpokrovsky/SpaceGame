using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Collider Boundary;

    private SpaceShipScript ship;

    void Awake()
    {
        ship = GetComponent<SpaceShipScript>();
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxis("Horizontal");
        float yMove = Input.GetAxis("Vertical");
        ship.Move(xMove, yMove, Boundary);
        if (Input.GetButton("Fire1")) {
            ship.ShootMainGun();
        }
        if (Input.GetButton("Fire2")) {
            ship.ShootExtraGun();
        }
    }
}
