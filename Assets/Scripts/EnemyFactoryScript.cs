using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyFactoryScript : MonoBehaviour
{
    public GameObject[] Asteroids;
    public GameObject[] SpaceShips;
    public float AsteroidsProbability = 0.8f;
    public int EnemiesCount = 20;
    public float EnemiesTimeout = 0.8f;
    public float WavesTimeout = 5;

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

    void Start() {
        Random.InitState ((int)System.DateTime.Now.Ticks);
        StartCoroutine(GenerateWaves());
    }

    private IEnumerator GenerateWaves() {
        while (true) {
            yield return new WaitForSeconds(WavesTimeout);
            foreach (int i in Enumerable.Range(0, EnemiesCount))
            {
                Vector3 p = new Vector3(Random.Range(minXPos, maxXPos), yPos, zPos);
                GenerateEnemy(p);
                yield return new WaitForSeconds(EnemiesTimeout);
            }
        }
    }

    private GameObject GenerateEnemy(Vector3 p) {
        if (Random.value < AsteroidsProbability) {
            int asteroidType = Random.Range(0, Asteroids.Length);
            return Instantiate(Asteroids[asteroidType], p, Quaternion.identity);
        } else {
            int shipType = Random.Range(0, SpaceShips.Length);
            GameObject ship = Instantiate(SpaceShips[shipType], p, Quaternion.identity);
            ship.AddComponent(typeof(EnemyScript));
            return ship;
        }
    }
}
