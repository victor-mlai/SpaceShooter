using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Controller : MonoBehaviour {

    public float fireRate;
    public GameObject bolt;

    private float nextFire = 0.0f;
    private GameObject go;
    private Vector2 boltDirection;
    private Vector2 boltPos;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFire)
        {
            for (int i = 0; i < 5; i++) {
                boltDirection.x = Mathf.Sin(2 * Mathf.PI * i / 5 + 2 * Time.time + 0.5f);
                boltDirection.y = Mathf.Cos(2 * Mathf.PI * i / 5 + 2 * Time.time + 0.5f);
                boltPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.z);
                boltPos += boltDirection * 0.5f;

                go = Instantiate(bolt, new Vector3(boltPos.x, 0.0f, boltPos.y), Quaternion.identity) as GameObject;
                go.GetComponent<Mover>().SendMessage("SetDirection", boltDirection);
            }
            nextFire = Time.time + fireRate;
        }
    }
}
