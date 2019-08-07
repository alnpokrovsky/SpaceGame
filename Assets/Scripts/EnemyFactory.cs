using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public GameObject Asteroid;
    public GameObject SpaceShip;
    public float Timeout = 1;

    private float minXPos;
    private float maxXPos;
    private float yPos;
    private float zPos;
    private Reloader reloader;

    void Awake()
    {
        minXPos = transform.position.x - transform.localScale.x/2;
        maxXPos = transform.position.x + transform.localScale.x/2;
        yPos = transform.position.y;
        zPos = transform.position.z;

        reloader = new Reloader(Timeout);
    }

    // Update is called once per frame
    void Update()
    {
        if (reloader.Ready) {
            reloader.Shot();
            Vector3 p = new Vector3(Random.Range(minXPos, maxXPos), yPos, zPos);
            if (Random.value > 0.2) {
                Instantiate(Asteroid, p, Quaternion.identity);
            } else {
                SpaceShip ship = Instantiate(SpaceShip, p, Quaternion.identity)
                .GetComponent<SpaceShip>();
                ship.gameObject.tag = "Enemy";
                ship.ZAngle = 180;
                ship.Move(0,1);
            }
        }
    }
}
