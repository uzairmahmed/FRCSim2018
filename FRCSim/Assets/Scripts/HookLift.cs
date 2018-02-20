using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookLift : MonoBehaviour {
    public float hookHeight;

    public float minHookHeight = 0.2f;
    public float maxHookHeight = 1.7f;

    public float speed = 1f;

    public GameObject HookUltrasonic;

    float vh;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        vh = Input.GetAxisRaw("Lift");

        GetHeight();

        if ((vh > 0) )//&& (hookHeight ))< maxHookHeight))
        {
            transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        }
        else if ((vh < 0) )//&& (hookHeight > minHookHeight))
        {
            transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
        }

    }

    void GetHeight()
    {
        RaycastHit hit;
        Ray downRay = new Ray(HookUltrasonic.transform.position, -Vector3.up);
        Physics.Raycast(downRay, out hit);
        hookHeight = hit.distance;
    }
}
