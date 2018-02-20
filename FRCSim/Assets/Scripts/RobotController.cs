using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour {
    public float intakeHeight;
    public float hookHeight;

    float forwardAxis;
    float sidewaysAxis;
    float liftAxis;
    float intakeLiftAxis;
    float intakeAxis;

    public float minIntakeHeight = 0.2f;
    public float medIntakeHeight = 1f;
    public float maxIntakeHeight = 1.7f;
    public float minHookHeight;
    public float maxHookHeight;

    public float liftSpeed = 1f;
    bool holdingCube = false;
    public Grabbed grabbedScript;

    public GameObject elevator;
    public GameObject intake;
    public GameObject intakeBar;
    public GameObject hookCylinder;
    public GameObject hookUltrasonic;

    public List<AxleInfo> axleInfos;
    public float maxMotorTorque = 15f;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        liftAxis = Input.GetAxisRaw("Lift");
        intakeLiftAxis = Input.GetAxisRaw("Lift");
        forwardAxis = Input.GetAxisRaw("Vertical");
        sidewaysAxis = Input.GetAxisRaw("Horizontal");
        intakeAxis = Input.GetAxisRaw("Grab");

        GetHookHeight();
        GetIntakeHeight();

        intakeLimiter();
        intakeGrab();
        hookLimiter();

        wheelSpin();
    }

    void intakeLimiter()
    {
        if ((intakeLiftAxis > 0) && (intakeHeight < medIntakeHeight))
        {
            intake.transform.Translate(new Vector3(0, 0, liftSpeed * Time.deltaTime));
        }
        else if ((intakeLiftAxis > 0) && (intakeHeight >= medIntakeHeight) && (intakeHeight <= maxIntakeHeight))
        {
            elevator.transform.Translate(new Vector3(0, liftSpeed * Time.deltaTime, 0));
        }
        else if ((intakeLiftAxis < 0) && (intakeHeight > medIntakeHeight))
        {
            elevator.transform.Translate(new Vector3(0, -liftSpeed * Time.deltaTime, 0));
        }
        else if ((intakeLiftAxis < 0) && (intakeHeight <= medIntakeHeight) && (intakeHeight >= minIntakeHeight))
        {
            intake.transform.Translate(new Vector3(0, 0, -liftSpeed * Time.deltaTime));
        }
    }

    void intakeGrab()
    {
        if ((intakeAxis > 0) && (holdingCube))
        {
            grabbedScript.SetGrabbed(false);
            grabbedScript.Shoot();
            holdingCube = false;
        }
    }

    void hookLimiter()
    {
        if ((liftAxis > 0) && (hookHeight < maxHookHeight))
        {
            hookCylinder.transform.Translate(new Vector3(0, liftSpeed * Time.deltaTime, 0));
        }
        else if ((liftAxis < 0) && (hookHeight > minHookHeight))
        {
            hookCylinder.transform.Translate(new Vector3(0, -liftSpeed * Time.deltaTime, 0));
        }
    }

    void wheelSpin()
    {
        foreach (AxleInfo axleInfo in axleInfos)
        {
            axleInfo.left.transform.Rotate(-axleInfo.left.motorTorque, 0, 0);
            axleInfo.right.transform.Rotate(axleInfo.left.motorTorque, 0, 0);

            if (forwardAxis != 0)
            {

                float motor = maxMotorTorque * forwardAxis;
                axleInfo.left.motorTorque = motor;
                axleInfo.right.motorTorque = motor;
            }
            else if (sidewaysAxis != 0)
            {
                float motor = maxMotorTorque * sidewaysAxis;// * 2;
                axleInfo.left.motorTorque = motor;
                axleInfo.right.motorTorque = -motor;
            }
            else
            {
                axleInfo.left.motorTorque = 0;
                axleInfo.right.motorTorque = 0;
            }
        }
    }

    void GetHookHeight()
    {
        RaycastHit hit;
        Ray downRay = new Ray(hookUltrasonic.transform.position, -Vector3.up);
        Physics.Raycast(downRay, out hit);
        hookHeight = hit.distance;
    }

    void GetIntakeHeight()
    {
        RaycastHit hit;
        Ray downRay = new Ray(intake.transform.position, -Vector3.up);
        Physics.Raycast(downRay, out hit);
        intakeHeight = hit.distance;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!holdingCube && collision.gameObject.tag == "cube" && intakeAxis < 0)
        {
            grabbedScript = collision.gameObject.GetComponent<Grabbed>();
            grabbedScript.SetGrabbed(true);
            holdingCube = true;
        }
    }
}


[System.Serializable]
public class AxleInfo
{
    public WheelCollider left;
    public WheelCollider right;
}