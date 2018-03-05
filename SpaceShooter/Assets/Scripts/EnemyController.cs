using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float fireRate;
    public GameObject bolt;
    public Transform shotSpawn;

    private float nextFire = 0.0f;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextFire)
        {
            Instantiate(bolt, shotSpawn.position, shotSpawn.rotation);
            nextFire = Time.time + fireRate;
        }
    }
}
