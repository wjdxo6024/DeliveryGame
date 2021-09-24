using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeMovingScript : MonoBehaviour
{

    public WheelCollider colliderFront;
    public WheelCollider colliderBack;

    public int maxTorque;
    // Start is called before the first frame update
    void Start()
    {
        maxTorque = 3000;
    }

    // Update is called once per frame
    void Update()
    {
        colliderFront.motorTorque = maxTorque * Input.GetAxis("Vertical");
        colliderBack.steerAngle = 15 * Input.GetAxis("Horizontal");
    }
}
