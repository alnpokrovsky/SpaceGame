﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RestartScript : MonoBehaviour
{
    // Start is called before the first frame update
    void OnMouseDown() {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }
}
