using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyFactoryScript : MonoBehaviour
{
    public GameObject[] Asteroids;
    public GameObject[] SpaceShips;
    public float AsteroidsProbability = 0.8f;

    private float minXPos;
    private float maxXPos;
    private float yPos;
    private float zPos;

    void Awake()
    {
        minXPos = transform.position.x - transform.localScale.x/2;
        maxXPos = transform.position.x + transform.localScale.x/2;
        yPos = transform.position.y;
        zPos = transform.position.z;
    }

    public GameObject GenerateEnemy() {
        Vector3 p = new Vector3(Random.Range(minXPos, maxXPos), yPos, zPos);

        if (Random.value < AsteroidsProbability) {
            int asteroidType = Random.Range(0, Asteroids.Length);
            return Instantiate(Asteroids[asteroidType], p, transform.rotation);
        } else {
            int shipType = Random.Range(0, SpaceShips.Length);
            GameObject ship = Instantiate(SpaceShips[shipType], p, transform.rotation);
            ship.AddComponent(typeof(EnemyScript));
            return ship;
        }
    }
}
