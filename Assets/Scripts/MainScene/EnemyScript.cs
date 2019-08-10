using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float ZAngle = 180;

    private SpaceShipScript ship;

    void Awake() {
        tag = "Enemy";
        ship = GetComponent<SpaceShipScript>();
        transform.rotation = Quaternion.Euler(0,0,180);
    }

    // Start is called before the first frame update
    void Start()
    {
        ship.Move(0,1);
    }

    // Update is called once per frame
    void Update()
    {
        ship.ShootMainGun();
    }
}
