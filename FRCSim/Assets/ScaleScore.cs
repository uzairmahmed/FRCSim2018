using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleScore : MonoBehaviour {
    public Text score;
    public Transform scale;
    public float scoreVal;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //scoreVal = Mathf.Round(scoreVal);
        score.text = Mathf.Round(scoreVal).ToString();
        //Debug.Log(scale.rotation.x);
        if (scale.rotation.x > 0.08)
        {
            Debug.Log(scoreVal);
            scoreVal += Time.deltaTime;
        }
        else
        {
           Debug.Log(scale.rotation.x);
        }

    }
}
