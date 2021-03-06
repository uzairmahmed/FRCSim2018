﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SpawnCube : MonoBehaviour {

    public GameObject player;
    public GameObject powerCube;
   
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "RobotPart")
        {
            player = collision.gameObject;
            SpawnACube();
        }
    }

    void SpawnACube()
    {
        var cube = (GameObject)Instantiate(powerCube, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.identity);
        NetworkServer.Spawn(cube);
    }
    
}

