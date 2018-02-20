using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    public ArrayList teams = new ArrayList();

    public GameObject red1;
    public GameObject red2;
    public GameObject red3;
    public GameObject blu1;
    public GameObject blu2;
    public GameObject blu3;

    public GameObject robot;

    int team;

    // Use this for initialization
    void Start () {
        team = 2; //Shaurya this is where your magic happens
        spawnRobot(team);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void spawnRobot(int t)
    {
        switch (t)
        {
            case 0:
                Instantiate(robot, red1.transform.position, Quaternion.identity);
                return;
            case 1:
                Instantiate(robot, red2.transform.position, Quaternion.identity);
                return;
            case 2:
                Instantiate(robot, red3.transform.position, Quaternion.identity);
                return;
            case 3:
                Instantiate(robot, blu1.transform.position, Quaternion.identity);
                return;
            case 4:
                Instantiate(robot, blu2.transform.position, Quaternion.identity);
                return;
            case 5:
                Instantiate(robot, blu3.transform.position, Quaternion.identity);
                return;

        }
    }
}
