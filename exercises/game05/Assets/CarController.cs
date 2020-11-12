using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    float moveSpeed = 500;
    float rotateSpeed = 120;

    public CharacterController cc;

    float gravityModifier = 1;
    float yVelocity = 0;

    Vector3 checkpoint;
    // Start is called before the first frame update
    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();
        checkpoint = new Vector3 (0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
        {
            transform.position = checkpoint;
        }
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        transform.Rotate(0, hAxis * rotateSpeed * Time.deltaTime, 0, Space.Self);

        if (cc.isGrounded)
        {
            yVelocity = 0;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                yVelocity = 10;
            }
        }

        yVelocity = yVelocity + Physics.gravity.y * gravityModifier * Time.deltaTime;

        Vector3 amountToMove = transform.forward * vAxis * moveSpeed * Time.deltaTime;

        amountToMove.y = yVelocity;

        cc.Move(amountToMove);

        Vector3 cameraPosition = transform.position - transform.forward * 50 + Vector3.up * 50;
        Camera.main.transform.position = cameraPosition;
        Vector3 lookAtPos = transform.position + transform.forward * 100;

        Camera.main.transform.LookAt(lookAtPos, Vector3.up);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EndofRoad"))
        {
            Debug.Log("Winner");
        }
    }
}
