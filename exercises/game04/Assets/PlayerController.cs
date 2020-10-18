using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float moveSpeed = 50;
    float rotateSpeed = 60;

    public CharacterController cc;

    bool prevIsGrounded = false;

    float yVelocity = 0;
    float jumpForce = 3f;
    float gravityModifier = 0.2f;

    public PlatformController PlatformAttachedTo;

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

        transform.Rotate(0, hAxis * rotateSpeed * Time.deltaTime, 0, Space.Self);

        if (!cc.isGrounded) {
            yVelocity = yVelocity = yVelocity + Physics.gravity.y * gravityModifier * Time.deltaTime;

            if (Input.GetKeyUp(KeyCode.Space) && yVelocity > 0) {
                yVelocity = 0;
            }
        } else { 
            if (prevIsGrounded) {
                yVelocity = 0;
            }

            if (Input.GetKeyDown(KeyCode.Space)) {
                yVelocity = jumpForce;
            }
        }

        yVelocity = yVelocity + Physics.gravity.y * gravityModifier * Time.deltaTime;

        Vector3 amountToMove = transform.forward * vAxis * moveSpeed * Time.deltaTime;

        amountToMove.y += yVelocity;

        if (PlatformAttachedTo != null) {
            amountToMove += PlatformAttachedTo.DistanceMoved;
        }

        
        cc.Move(amountToMove);

        prevIsGrounded = cc.isGrounded;
    }
}
