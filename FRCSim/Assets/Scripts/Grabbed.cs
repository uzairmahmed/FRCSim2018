using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbed : MonoBehaviour {
    public Transform bot;
    public bool grabbed = false;
    public float offset;
    public Transform elevatorHeight;
    public Rigidbody rb;

	// Use this for initialization
	void Start () {
		
	}


    public void SetGrabbed(bool value)
    {
        grabbed = value;
    }
    public void Shoot()
    {
        rb.useGravity = true;
        transform.position = bot.position + (float)0.8*bot.transform.right;
        rb.AddRelativeForce(5, 0, 0);

    }



    // Update is called once per frame
    void Update () {
        //elevatorOffset.Set(0, elevatorHeight.position.y-(float)0.3, 0);
        if (grabbed)
        {
            rb.useGravity = false;
            transform.position = bot.position + bot.transform.right * offset;
            transform.rotation = bot.rotation;

        }

	}
}
