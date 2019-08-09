using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSpaceScript : MonoBehaviour
{
    public float ScrollSpeed = 0.1F;

    private CanvasRenderer rend;

    void Awake()
    {
        rend = GetComponent<CanvasRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Time.time * ScrollSpeed;
        rend?.GetMaterial()?.SetTextureOffset("_MainTex", new Vector2(0, offset));
    }
}
