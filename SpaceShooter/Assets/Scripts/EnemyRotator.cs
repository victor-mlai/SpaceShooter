using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotator : MonoBehaviour {
    public float speed;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0.0f, speed, 0.0f);
    }

}
