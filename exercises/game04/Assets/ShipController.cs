using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipController : MonoBehaviour
{
    public GameObject BulletPrefab;

    public GameObject PlayerPrefab;

    Rigidbody rb;

    float speed = 4;
    float maxSpeed = 20;
    float forwardSpeed = 1;
    float pitchSpeed = 30;
    float pitchModSpeedRate = 200f;
    float rollSpeed = 30;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");


        float xRot = vAxis * pitchSpeed * Time.deltaTime;
        float yRot = hAxis * rollSpeed / 4 * Time.deltaTime;
        float zRot = -hAxis * rollSpeed * Time.deltaTime;
        transform.Rotate(xRot, yRot, zRot, Space.Self);

        forwardSpeed += -transform.forward.y * pitchModSpeedRate * Time.deltaTime;
        forwardSpeed = Mathf.Clamp(forwardSpeed, 0, 5f);

        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);

        if (forwardSpeed <= 0.2f) {
            rb.isKinematic = false;
            rb.useGravity = false;

        }

        if (Input.GetKey(KeyCode.W)) {
            speed += 1;

        }

        if (speed > 0) {
            speed -= 4 * Time.deltaTime;
        }

        float terrainHeight = Terrain.activeTerrain.SampleHeight(transform.position);
        if (transform.position.y < terrainHeight) {
            transform.position = new Vector3(transform.position.x, terrainHeight, transform.position.z);
        }

        Vector3 cameraPosition = transform.position - transform.forward * 2 + Vector3.up * 2;
        Camera.main.transform.position = cameraPosition;
        Vector3 lookAtPos = transform.position + transform.forward * 1;

        Camera.main.transform.LookAt(lookAtPos, Vector3.up);

        if (Input.GetKeyDown(KeyCode.Space)) {
            GameObject Bullet = Instantiate(BulletPrefab, transform.position + transform.forward * 10, Quaternion.identity);
            Rigidbody BulletRB = Bullet.GetComponent<Rigidbody>();
            BulletRB.AddForce(transform.forward * 5000);
            Destroy(Bullet, 5);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(PlayerPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}