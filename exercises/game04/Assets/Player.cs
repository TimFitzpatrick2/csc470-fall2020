using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float moveSpeed = 12;
    float rotateSpeed = 120;

    public CharacterController cc;


    float yVelocity = 0;
    float jumpForce = 0.3f;
    float fall = -1;
    

    // Start is called before the first frame update
    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        transform.Rotate(0, hAxis * rotateSpeed * Time.deltaTime, 0);

    

        Vector3 amountToMove = transform.forward * vAxis * moveSpeed * Time.deltaTime;

        amountToMove.y = yVelocity;

        cc.Move(amountToMove);

        if (Input.GetKeyDown(KeyCode.Space)) {
            yVelocity = jumpForce;
        }

        if (Input.GetKey(KeyCode.S)) {
            yVelocity = fall;
        }

        Vector3 cameraPosition = transform.position - transform.forward * 2 + Vector3.up * 2;
        Camera.main.transform.position = cameraPosition;
        Vector3 lookAtPos = transform.position + transform.forward * 1;

        Camera.main.transform.LookAt(lookAtPos, Vector3.up);
    }
}
