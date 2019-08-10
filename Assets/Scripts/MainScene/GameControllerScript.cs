using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    public Text ScoreText;
    public Text WaveText;
    public GameObject GameOverText;

    public int EnemiesCount = 20;
    public float EnemiesTimeout = 0.8f;
    public float WavesTimeout = 5;


    private bool gameOver = false;
    public bool GameOver {
        get { return gameOver; }
        set {
            gameOver = true;
            GameOverText.gameObject.SetActive(true);
        }
    }

    private int score;
    public int Score {
        get { return score; }
        set { 
            score = value;
            ScoreText.text = "Счет: " + score;
        }
    }

    private int wave;
    public int Wave {
        get { return wave; }
        private set {
            wave = value;
            WaveText.text = wave + " Волна";
        }
    }


    private IEnumerator TimedScore() {
        while (!GameOver) {
            Score += 1;
            yield return new WaitForSeconds(1);
        }
    }

    private IEnumerator GenerateWaves(EnemyFactoryScript factory) {
        while (!GameOver) {
            yield return new WaitForSeconds(WavesTimeout);
            
            Wave += 1;
            for (int i = 0; i < EnemiesCount; ++i)
            {
                factory.GenerateEnemy();
                yield return new WaitForSeconds(EnemiesTimeout);
            }
        }
    }

    void Start() {
        EnemyFactoryScript factory = GameObject.FindGameObjectWithTag("Respawn")
            .GetComponent<EnemyFactoryScript>();
        StartCoroutine(GenerateWaves(factory));
        StartCoroutine(TimedScore());
    }

}
