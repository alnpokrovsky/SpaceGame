using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Collider GameBoundary;

    private SpaceShipScript ship;
    private Bounds shipBounds;
    private GameControllerScript gameController;

    void Awake()
    {
        ship = GetComponent<SpaceShipScript>();
    }

    void Start() {
        shipBounds = ContentBounds.Box(this.gameObject).Value;
        gameController = GameObject.FindWithTag("GameController")
            .GetComponent<GameControllerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxis("Horizontal");
        float yMove = Input.GetAxis("Vertical");
        ship.Move(xMove, yMove);
        if (GameBoundary != null) {
            Vector3 center = GameBoundary.bounds.center - shipBounds.center;
            Vector3 extents = GameBoundary.bounds.extents - shipBounds.extents;
            float xPos = Mathf.Clamp(transform.position.x,
                                center.x - extents.x,
                                center.x + extents.x);
            float yPos = Mathf.Clamp(transform.position.y, 
                                center.y - extents.y,
                                center.y + extents.y);
            transform.position = new Vector3(xPos, yPos, transform.position.z);
        }
        if (Input.GetButton("Fire1")) {
            if (ship.ShootMainGun()) {
                gameController.Score -= 10;
            }
        }
        if (Input.GetButton("Fire2")) {
            if (ship.ShootExtraGun()) {
                gameController.Score -= 20;
            }
        }
    }

    void OnDestroy() {
        gameController.GameOver = true;
    }
}
