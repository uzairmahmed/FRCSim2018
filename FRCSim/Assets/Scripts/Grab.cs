using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour {
    bool holding = false;
    public Grabbed grabbedScript;
    //public Transform parent;



    // Use this for initialization
    void Start () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hit");
        if (!holding && collision.gameObject.tag == "cube")
        {
            grabbedScript = collision.gameObject.GetComponent<Grabbed>();
            grabbedScript.SetGrabbed(true);
            holding = true;
        }
    }


    // Update is called once per frame
    void Update () {
      //  transform.position = parent.position + parent.transform.forward*(float)2.2;
       // transform.rotation = parent.rotation;

        if (Input.GetKey("e") && holding)
        {
            grabbedScript.SetGrabbed(false);
            grabbedScript.Shoot();
            holding = false;
            Debug.Log("throw");
        }

    }
}
