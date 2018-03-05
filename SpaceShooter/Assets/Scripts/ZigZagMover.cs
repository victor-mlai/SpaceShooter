using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagMover : MonoBehaviour {
	// Update is called once per frame
	void Update () {
        if (transform.position.x < -4.5f)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(Mathf.Abs(GetComponent<Rigidbody>().velocity.x),
                                                             0.0f,
                                                             GetComponent<Rigidbody>().velocity.z);
        }

        if (transform.position.x > 4.5f)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(-Mathf.Abs(GetComponent<Rigidbody>().velocity.x),
                                                             0.0f,
                                                             GetComponent<Rigidbody>().velocity.z);
        }
    }
}
