using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneCube : MonoBehaviour {
    public Rigidbody cube;
    public Rigidbody bot;
    public Transform startingPosition;

	// Use this for initialization
	void Start () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "RobotPart")
        {
            Instantiate(cube, startingPosition.position, startingPosition.rotation);
            bot.AddRelativeForce(1000, 0, 0);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
