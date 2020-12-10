using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorScript : MonoBehaviour
{
    public Animator anim;

    public Vector3 DistanceMoved = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, 0.6f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MovingTarget"))
        {
            MovingTargetScript MovingTarget = other.gameObject.GetComponent<MovingTargetScript>();
            MovingTarget.PlatformAttachedTo = this;
        }
    }
}
