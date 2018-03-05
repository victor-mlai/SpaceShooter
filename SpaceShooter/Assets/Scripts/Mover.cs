using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
    public float speed;
    public Vector2 direction;

    void Start()
    {
        //rigidbody.velocity = transform.forward * speed;
        direction = direction.normalized;
        if (GetComponent<Rigidbody>().velocity.sqrMagnitude == 0.0f)
            GetComponent<Rigidbody>().velocity = new Vector3(speed * direction.x, 0.0f, speed * direction.y);
    }

    void SetDirection(Vector2 direction)
    {
        GetComponent<Rigidbody>().velocity = new Vector3(speed * direction.x, 0.0f, speed * direction.y);
    }
}
