using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbed : MonoBehaviour {
    public bool grabbed = false;
    public GameObject intake;
    public Rigidbody rb;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        if (grabbed)
        {
            rb.useGravity = false;
            transform.position = intake.transform.position;
            transform.rotation = intake.transform.rotation;
        }
    }

    public void SetGrabbed(bool value)
    {
        grabbed = value;
    }
    public void Shoot()
    {
        rb.useGravity = true;
        transform.position = intake.transform.position+ (float)0.8*intake.transform.right;
        rb.AddRelativeForce(10, 0, 0);
    }
    
    
}
