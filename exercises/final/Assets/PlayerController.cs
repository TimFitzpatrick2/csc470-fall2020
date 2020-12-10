using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject ArrowPrefab;

    float rotateSpeed = 75;

    float forceSpeed = 5500;

    Rigidbody rb;

    public CharacterController cc;

    public int score = 5;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        cc = gameObject.GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        float zAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");



        transform.Rotate(0, zAxis * rotateSpeed * Time.deltaTime, 0, Space.Self);
        transform.Rotate(yAxis * rotateSpeed * Time.deltaTime, 0, 0, Space.Self);



        Vector3 cameraPosition = transform.position - transform.forward * 35 + Vector3.up * 10;
        Camera.main.transform.position = cameraPosition;
        Vector3 lookAtPos = transform.position + transform.forward * 0;

        Camera.main.transform.LookAt(lookAtPos, Vector3.up);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject Arrow = Instantiate(ArrowPrefab, transform.position + transform.forward * 10, transform.rotation);
            Rigidbody ArrowRB = Arrow.GetComponent<Rigidbody>();
            ArrowRB.AddForce(transform.forward * forceSpeed);
            Destroy(Arrow, 5);

        }

    }
}
