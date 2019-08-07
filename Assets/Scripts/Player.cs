using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public BoxCollider Boundary;

    private SpaceShip ship;

    void Awake()
    {
        ship = GetComponent<SpaceShip>();
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
