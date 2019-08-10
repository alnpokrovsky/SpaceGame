using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartScript : MonoBehaviour
{
    public Vector3 ReadyPosition;
    public GameObject[] UITexts;

    private Rigidbody body;

    void Awake() {
        body = GetComponent<Rigidbody>();
    }


    void OnMouseDown() {
        GetComponent<Animation>().Play("GetReady");

        foreach (GameObject t in UITexts) {
            t.SetActive(false);
        }
    }

    void Update() {
        if (transform.position == ReadyPosition) {
            SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        }
    }
}
