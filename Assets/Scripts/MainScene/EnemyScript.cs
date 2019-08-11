using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float ZAngle = 180;

    private SpaceShipScript ship;
    private GameObject player;

    void Awake() {
        tag = "Enemy";
        ship = GetComponent<SpaceShipScript>();
        player = GameObject.FindWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        ship.Move(Random.value-0.5f, 0.5f+Random.value);
    }

    // Update is called once per frame
    void Update()
    {
        // ship.TargetAt(player);
        // ship.Move(0, 1, Quaternion.Euler(0,0,180));
        ship.ShootMainGun();
    }
}
