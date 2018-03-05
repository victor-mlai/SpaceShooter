using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;

    private GameController gameController;
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null) {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        else {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }

        if (other.tag == "Player")
        {
            Time.timeScale = 0.5f;
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }

        if (this.tag != "EnemyBolt")
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        gameController.AddToScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }
}
