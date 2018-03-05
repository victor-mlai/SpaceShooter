using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float minX, maxX, minZ, maxZ;
}

public class PlayerController : MonoBehaviour {

    public float speed;
    public float tilt;
    public Boundary boundary;
    public GameObject bolt;
    public Transform shotSpawn;
    private float nextFire = 0.0f;
    public float fireRate;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            Instantiate(bolt, shotSpawn.position, shotSpawn.rotation);
            nextFire = Time.time + fireRate;
        }
    }

    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;
        float moveVertical = Input.GetAxis("Vertical") * Time.fixedDeltaTime * speed;

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        GetComponent<Rigidbody>().velocity = movement;

        GetComponent<Rigidbody>().position = new Vector3(
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.minX, boundary.maxX),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.minZ, boundary.maxZ)
            );

        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 180.0f, GetComponent<Rigidbody>().velocity.x * tilt);
    }
}
