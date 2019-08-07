using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSpace : MonoBehaviour
{
    public float ScrollSpeed = 0.1F;

    private Renderer rend;

    void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Time.time * ScrollSpeed;
        rend.material.mainTextureOffset = new Vector2(0, offset);
    }
}
