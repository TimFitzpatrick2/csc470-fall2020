using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class BoatController : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Debug.Log("All aboard: " + gameObject.name);


    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, 0.5f);
    }
}
