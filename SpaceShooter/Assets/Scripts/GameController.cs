using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public GameObject[] asteroids;    
    public GameObject[] enemies;
    public Vector3 spawnRange;
    public float startTime;
    public float wavePauseTime;
    public float enemySpawnTime;

    public bool gameOver;
    public bool restart;
    public Text scoreText;
    public Text gameOverText;
    public Text restartText;
    public int score;

    // Use this for initialization
    void Start () {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
	}

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Time.timeScale = 1.0f;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    IEnumerator SpawnWave1()
    {
        int nr = 20;    // Spawn 'nr' asteroids in 'wavePauseTime' seconds
        for (int i = 0; i < nr; i++)
        {
            Instantiate(asteroids[Random.Range(0, asteroids.Length)], new Vector3(Random.Range(-spawnRange.x, spawnRange.x),
                                        spawnRange.y,
                                        spawnRange.z), Quaternion.identity);

            yield return new WaitForSeconds(wavePauseTime/ nr);
        }
    }

    IEnumerator SpawnWave2()
    {
        int nr = 4; // Spawn 'nr' enemies1 in 'wavePauseTime' seconds
        for (int i = 0; i < nr; i++)
        {
            Instantiate(enemies[0], new Vector3(Random.Range(-spawnRange.x, spawnRange.x),
                                        spawnRange.y,
                                        spawnRange.z), Quaternion.identity);

            yield return new WaitForSeconds(wavePauseTime / nr);
        }
    }

    IEnumerator SpawnWave3()
    {
        int nr = 2;
        for (int i = 0; i < nr; i++)
        {
            Instantiate(enemies[1], new Vector3(Random.Range(-spawnRange.x, spawnRange.x),
                                        spawnRange.y,
                                        spawnRange.z), Quaternion.identity);

            yield return new WaitForSeconds(wavePauseTime / nr);
        }
    }

    IEnumerator SpawnWave4()
    {
        int nr = 4;
        for (int i = 0; i < nr; i++)
        {
            Instantiate(enemies[2], new Vector3(Random.Range(-spawnRange.x, spawnRange.x),
                                        spawnRange.y,
                                        spawnRange.z), Quaternion.identity);

            yield return new WaitForSeconds(wavePauseTime / nr);
        }
    }

    IEnumerator SpawnWave5()
    {
        int nr = 1;    // Spawn 'nr' asteroids in 'wavePauseTime' seconds
        for (int i = 0; i < nr; i++)
        {
            Instantiate(asteroids[Random.Range(0, asteroids.Length)], new Vector3(Random.Range(-spawnRange.x, 0),
                                        spawnRange.y,
                                        spawnRange.z), Quaternion.identity);

            Instantiate(enemies[2], new Vector3(Random.Range(0, spawnRange.x),
                                    spawnRange.y,
                                    spawnRange.z), Quaternion.identity);

            yield return new WaitForSeconds(enemySpawnTime);
        }

        for (int i = 0; i < nr; i++)
        {
            Instantiate(enemies[1], new Vector3(Random.Range(0, spawnRange.x),
                                    spawnRange.y,
                                    spawnRange.z), Quaternion.identity);

            Instantiate(enemies[0], new Vector3(Random.Range(-spawnRange.x, 0),
                                    spawnRange.y,
                                    spawnRange.z), Quaternion.identity);

            yield return new WaitForSeconds(enemySpawnTime);
        }
    }

    IEnumerator SpawnWave6()
    {

        Instantiate(enemies[2], new Vector3(Random.Range(-spawnRange.x, - 2 * spawnRange.x / 3),
                                spawnRange.y,
                                spawnRange.z), Quaternion.identity);

        Instantiate(enemies[1], new Vector3(Random.Range(-2 * spawnRange.x / 3, spawnRange.x /3),
                                spawnRange.y,
                                spawnRange.z), Quaternion.identity);

        Instantiate(enemies[0], new Vector3(Random.Range(spawnRange.x / 3, spawnRange.x),
                                spawnRange.y,
                                spawnRange.z), Quaternion.identity);

        yield return new WaitForSeconds(wavePauseTime / 6);

        Instantiate(enemies[0], new Vector3(Random.Range(-spawnRange.x, -2 * spawnRange.x / 3),
                                    spawnRange.y,
                                    spawnRange.z), Quaternion.identity);

        Instantiate(enemies[2], new Vector3(Random.Range(-2 * spawnRange.x / 3, spawnRange.x / 3),
                                spawnRange.y,
                                spawnRange.z), Quaternion.identity);

        Instantiate(enemies[1], new Vector3(Random.Range(spawnRange.x / 3, spawnRange.x),
                                spawnRange.y,
                                spawnRange.z), Quaternion.identity);

    }

    IEnumerator SpawnWave7()
    {
        GameObject go;
        int nr = 10;    // Spawn 'nr' asteroids in 'wavePauseTime' seconds
        for (int i = 0; i < nr; i++)
        {
            go = Instantiate(asteroids[Random.Range(0, asteroids.Length)], new Vector3(-6.0f,
                                        spawnRange.y,
                                        Random.Range(0, spawnRange.z + 8.0f)), Quaternion.identity) as GameObject;
            go.GetComponent<Mover>().direction.x = 1;
            yield return new WaitForSeconds(wavePauseTime / nr);
        }
    }

    IEnumerator SpawnWaves()
    {
        int nrOfLevels = 7;
        int level;

        yield return new WaitForSeconds(startTime);
        while (!gameOver)
        {
            //Spawn Random Levels
            level = Random.Range(1, nrOfLevels + 1);
            //level = 7;
            switch (level)
            {
                case 1:
                    StartCoroutine(SpawnWave1());
                    break;
                case 2:
                    StartCoroutine(SpawnWave2());
                    break;
                case 3:
                    StartCoroutine(SpawnWave3());
                    break;
                case 4:
                    StartCoroutine(SpawnWave4());
                    break;
                case 5:
                    StartCoroutine(SpawnWave5());
                    break;
                case 6:
                    StartCoroutine(SpawnWave6());
                    break;
                case 7:
                    StartCoroutine(SpawnWave7());
                    break;
                default:
                    break;
            }

            level = Random.Range(1, nrOfLevels + 1);
            //level = 7;
            switch (level)
            {
                case 1:
                    StartCoroutine(SpawnWave1());
                    break;
                case 2:
                    StartCoroutine(SpawnWave2());
                    break;
                case 3:
                    StartCoroutine(SpawnWave3());
                    break;
                case 4:
                    StartCoroutine(SpawnWave4());
                    break;
                case 5:
                    StartCoroutine(SpawnWave5());
                    break;
                case 6:
                    StartCoroutine(SpawnWave6());
                    break;
                case 7:
                    StartCoroutine(SpawnWave7());
                    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(wavePauseTime);
        }
    }

    public void GameOver()
    {
        gameOver = true;
        restart = true;
        gameOverText.text = "Game Over";
        restartText.text = "Press R to restart";
    }

    public void AddToScore(int enemyScore)
    {
        score += enemyScore;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;

    }
}
