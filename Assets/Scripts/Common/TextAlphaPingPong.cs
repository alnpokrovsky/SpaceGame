using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAlphaPingPong : MonoBehaviour
{
    public float Period = 1;

    private Text text;

    void Awake(){
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.color = new Color(
            text.color.r, text.color.b, text.color.b,
            Mathf.PingPong(Time.time/Period, 1) 
        );
    }
}
