using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LouieController : MonoBehaviour
{
    float speed = 50f;
    float rotateSpeed = 150f;
    int score = 0;

    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        transform.Rotate(0, hAxis * rotateSpeed * Time.deltaTime, 0, Space.World);

        transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);

        if (speed > 0)
        {
            speed -= 4 * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            speed += 100;
        }

        speed = Mathf.Clamp(speed, 0, 100);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Worldz"))
            
            Destroy(other.gameObject);
            score++;
            scoreText.text = score.ToString();

    }
}
