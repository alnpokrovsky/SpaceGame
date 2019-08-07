using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public GameObject Asteroid;
    public float Timeout = 1;

    private float minXPos;
    private float maxXPos;
    private float yPos;
    private float zPos;
    private Reloader reloader;

    // Start is called before the first frame update
    void Start()
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
            Instantiate(Asteroid, p, Quaternion.identity);
        }
    }
}
