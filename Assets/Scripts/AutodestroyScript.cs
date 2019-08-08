using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutodestroyScript : MonoBehaviour
{
    public float Timeout = 5;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, Timeout);
    }
}
