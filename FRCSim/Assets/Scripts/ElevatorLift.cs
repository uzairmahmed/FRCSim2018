using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorLift : MonoBehaviour {
    public float intakeHeight;

    public float minHeight = 0.2f;
    public float medHeight = 1f;
    public float maxHeight = 1.7f;

    public float speed = 1f;

    public GameObject elevator;
    
    float vv;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        vv = Input.GetAxisRaw("Lift");

        GetHeight();

        if ((vv > 0) && (intakeHeight<medHeight))
        {
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        }
        else if ((vv > 0) && (intakeHeight >= medHeight) && (intakeHeight <= maxHeight))
        {
            elevator.transform.Translate(new Vector3(0, speed * Time.deltaTime,0));
        }
        else if ((vv < 0) && (intakeHeight > medHeight))
        {
            elevator.transform.Translate(new Vector3(0,-speed * Time.deltaTime,0));
        }
        else if ((vv < 0) && (intakeHeight <= medHeight) && (intakeHeight >= minHeight))
        {
            transform.Translate(new Vector3(0,0,-speed * Time.deltaTime));
        }

    }

    void GetHeight()
    {
        RaycastHit hit;
        Ray downRay = new Ray(transform.position, -Vector3.up);
        Physics.Raycast(downRay, out hit);
        intakeHeight = hit.distance;
    }
}
