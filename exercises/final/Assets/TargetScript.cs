﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetScript : MonoBehaviour
{
    float freq = 1f;
    float amp = 100f;

    
    float theta = 0;

    Vector3 startPosition;
    Vector3 previousPosition;
    public Vector3 DistanceMoved = Vector3.zero;

   

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        previousPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        theta += Time.deltaTime;

        Vector3 newPos = startPosition + transform.forward * Mathf.Sin(theta * freq) * amp;
        transform.position = newPos;

        DistanceMoved = transform.position - previousPosition;

        previousPosition = transform.position;

        
    }
}
