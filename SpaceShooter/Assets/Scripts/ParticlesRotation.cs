using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesRotation : MonoBehaviour {
    Enemy3Controller parent;
	// Use this for initialization
	void Start () {
        parent = GetComponentInParent<Enemy3Controller>();
	}
	
	// Update is called once per frame
	void Update () {
        float angle = Quaternion.Angle(Quaternion.identity, parent.gameObject.transform.rotation);
        //Debug.Log(angle);
        GetComponent<ParticleSystem>().startRotation = Mathf.Deg2Rad * angle;
    }
}
