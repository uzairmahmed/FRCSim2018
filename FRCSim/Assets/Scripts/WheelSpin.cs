using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Spins the wheels
 **/
 
public class WheelSpin : MonoBehaviour {
    public List <AxleInfo> axleInfos;
    public float maxMotorTorque;

    float v;
    float h;

    public void FixedUpdate()
    {
        v = Input.GetAxisRaw("Vertical");
        h = Input.GetAxisRaw("Horizontal");

        foreach (AxleInfo axleInfo in axleInfos)
        {
            axleInfo.left.transform.Rotate(-axleInfo.left.motorTorque*Time.deltaTime, 0, 0);
            axleInfo.right.transform.Rotate(axleInfo.left.motorTorque*Time.deltaTime, 0, 0);

            if (v != 0)
            {
                float motor = maxMotorTorque * v;
                axleInfo.left.motorTorque = motor;
                axleInfo.right.motorTorque = motor;
            }

            else if (h != 0)
            {
                float motor = maxMotorTorque * h;
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

    [System.Serializable]
    public class AxleInfo
    {
        public WheelCollider left;
        public WheelCollider right;
    }
}
