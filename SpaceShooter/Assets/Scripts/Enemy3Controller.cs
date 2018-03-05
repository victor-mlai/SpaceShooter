using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Controller : MonoBehaviour {

    private PlayerController playerShip;
    private EnginesVisibility engines_Ship;
    public float speed;
    public float retargetingRate;
    private float nextFire = 0.0f;

    private GameController playerController;
    private GameObject ShipEnginesObject;
    //private ParticleSystem[] particleSystem;
    void Start()
    {
        GameObject playerControllerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerControllerObject != null)
        {
            playerShip = playerControllerObject.GetComponent<PlayerController>();
        }
        else
        {
            Debug.Log("Cannot find 'PlayerController' script");
        }

        ShipEnginesObject = GameObject.FindGameObjectWithTag("Enemy3Engines");
        if (ShipEnginesObject != null)
        {
            engines_Ship = ShipEnginesObject.GetComponent<EnginesVisibility>();
            //particleSystem = engines_Ship.GetComponentsInChildren<ParticleSystem>();
        }
        else
        {
            Debug.Log("Cannot find 'PlayerController' script");
        }
        ShipEnginesObject.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        Vector3 direction;
        if (playerShip)
            direction = playerShip.transform.position - transform.position;
        else
            direction = new Vector3(1.0f, 0.0f, 0.0f);
        direction = direction.normalized;

        if (Time.time > nextFire)
        {
            if (ShipEnginesObject)
            {
                ShipEnginesObject.SetActive(true);
                //foreach (ParticleSystem ps in particleSystem)
                //{
                //    ps.startRotation = Quaternion.LookRotation(direction).x;
                //}
            }

            Invoke("StopJets", retargetingRate/4);
            GetComponent<Rigidbody>().velocity = direction * speed;
            nextFire = Time.time + retargetingRate;
        }

        transform.rotation = Quaternion.LookRotation(direction);

    }

    private void StopJets()
    {
        if (ShipEnginesObject)
            ShipEnginesObject.SetActive(false);
    }
}
