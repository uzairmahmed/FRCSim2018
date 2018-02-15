using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSwitch : MonoBehaviour {
    public Camera camera1;
    public Camera camera2;
    public Camera camera3;
    public float activeCamera = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("c"))
        {
            activeCamera++;
        }
        if (activeCamera > 2)
        {
            activeCamera = 0;
        }

        if(activeCamera == 0)
        {
            camera1.enabled = true;
            camera2.enabled = false;
            camera3.enabled = false;
        }
        if (activeCamera == 1)
        {
            camera1.enabled = false;
            camera2.enabled = true;
            camera3.enabled = false;
        }
        if (activeCamera == 2)
        {
            camera1.enabled = false;
            camera2.enabled = false;
            camera3.enabled = true;
        }
    }
}
