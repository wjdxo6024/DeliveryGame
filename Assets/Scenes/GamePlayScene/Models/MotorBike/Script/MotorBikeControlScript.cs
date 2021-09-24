using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorBikeControlScript : MonoBehaviour
{
    private float inputX, inputY;

    private Vector3 m_beforeVector;
    private Vector3 m_currentVector;

    // Start is called before the first frame update
    void Start()
    {
        m_beforeVector = transform.position;
        m_currentVector = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        AnimateWheels();
        GetInputs();

        Turn();
    }

    private void GetInputs()
    {
        MotorBikePhysicsScript gm = GetComponent<MotorBikePhysicsScript>();
        var input = new MotorInput();

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) // 전진
        {
            input.acceleration = 1f;
        }
        else if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            input.steer += 1;
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            input.steer -= 1;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) // 후진
        {
            input.brakeBack = 0.3f;
            input.brakeForward = 0.8f;
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            input.brakeBack = 1f;
        }
        else
        {
            input.brakeBack = 0.1f;
        }

        Move(gm.WheelUpdate(input));
    }

    private void Move(MotorInput input)
    {
        MotorBikePhysicsScript gm = GetComponent<MotorBikePhysicsScript>();
        gm.Turn(input.steer);
        gm.Forward(input.acceleration);
        gm.StopFront(input.brakeForward);
        gm.StopBack(input.brakeBack);
    }

    private void Turn()
    {
        MotorBikePhysicsScript bikePhysicsComponent = GetComponent<MotorBikePhysicsScript>();
        if(inputX < 0)
        {
            bikePhysicsComponent.TurnLeft(inputX);
        }
        else if(inputY > 0)
        {
            bikePhysicsComponent.TurnRight(inputX);
        }
        else
        {
            bikePhysicsComponent.Turn(inputX);
        }
    }

    private void AnimateWheels()
    {
        List<Wheel> wheels = GetComponent<MotorBikePhysicsScript>().GetWheels();
        foreach(var wheel in wheels)
        {
            Quaternion wheelRotation;
            Vector3 wheelPosition;
            wheel.collider.GetWorldPose(out wheelPosition, out wheelRotation);
            wheel.model.transform.position = wheelPosition;
            wheel.model.transform.rotation = wheelRotation;
        }
    }

}
