using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Axel
{
    Front,
    Rear
}

public struct MotorInput
{
    public float steer;
    public float acceleration;
    public float brakeForward;
    public float brakeBack;
}

[Serializable] // 엔진에서 직접 삽입할 수 있도록 강제 노출, 문서 참조
public struct Wheel
{
    public GameObject model;
    public WheelCollider collider;
    public float rotation;
    public Axel axel;
}

public class MotorBikePhysicsScript : MonoBehaviour
{
    [SerializeField]
    private float maxAcceleration = 200f;

    [SerializeField]
    private float turnSensitivity = 1.0f; // 회전 속도

    [SerializeField]
    private float maxSteerAngle = 45.0f; // 최대 회전 각도

    [SerializeField]
    private Vector3 centerOfMass;

    [SerializeField]
    private List<Wheel> wheels; // 2개의 바퀴

    private Rigidbody m_playerRigidBody;

    //private float m_maxSpeed;
    private Transform prevTrans;
    private Transform curTrans;
    private float m_curSpeed;
    public float wheelOffset = 0.1f;

    private Vector3 prevPos = new Vector3();
    private float prevAngle = 0;
    private float prevOmega = 0;
    private float speedVal = 0;
    private float prevSteer = 0f;

    public float steerSensivity = 30;
    public float controlAngle = 25;
    public float controlOmega = 30;

    // Start is called before the first frame update
    void Start()
    {
        prevTrans = transform;


        //// Wheel 초기화
        //for(int i = 0; i < 2; i++)
        //{
        //    Wheel tmpWheel = new Wheel();
        //    tmpWheel.axel = wheels[i].axel;
        //    tmpWheel.model = wheels[i].model;
        //    tmpWheel.collider = wheels[i].collider;
        //    tmpWheel.WheelStartPos = wheels[i].model.transform.localPosition;
        //    wheels[i] = tmpWheel;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // 속도
        curTrans = transform;
        var speed = (curTrans.position - prevTrans.position) / Time.deltaTime;

        m_curSpeed = speed.magnitude;
        prevTrans = curTrans;
        //// rigidbody
        //Rigidbody rigidbody = GetComponent<Rigidbody>();
        //rigidbody.MovePosition(position);
    }

    public void Waiting()
    {
        foreach (var wheel in wheels)
        {
            wheel.collider.motorTorque = 0;
        }
    }

    public void Forward(float inputY)
    {
        foreach(var wheel in wheels)
        {
            if (wheel.axel == Axel.Rear)
            {
                wheel.collider.motorTorque = inputY * maxAcceleration * 100 * 2;
                Debug.Log("motorTroque : " + wheel.collider.motorTorque);
            }
        }
    }

    public void Backward(float inputY)
    {
        foreach (var wheel in wheels)
        {
            if (wheel.axel == Axel.Rear)
            {
                wheel.collider.motorTorque = -inputY * maxAcceleration * 50;
                Debug.Log("motorTroque : " + wheel.collider.motorTorque);
            }
        }
    }

    public void StopFront(float inputY)
    {
        foreach(var wheel in wheels)
        {
            if (wheel.axel == Axel.Front)
            {
                wheel.collider.brakeTorque = inputY * maxAcceleration * 100 * 2;
                Debug.Log("Front brakeTorque : " + wheel.collider.brakeTorque);
            }
        }
    }

    public void StopBack(float inputY)
    {
        foreach (var wheel in wheels)
        {
            if (wheel.axel == Axel.Rear)
            {
                wheel.collider.brakeTorque = inputY * maxAcceleration * 100 * 4;
                Debug.Log("Back brakeTorque : " + wheel.collider.brakeTorque);
            }
        }
    }

    public void TurnLeft(float inputX)
    {
        var steerAngle = 0.0f;
        foreach (var wheel in wheels)
        {
            if (wheel.axel == Axel.Front)
            {
                wheel.collider.steerAngle = Mathf.Clamp(inputX, -1, 1) * maxSteerAngle;
                steerAngle = wheel.collider.steerAngle;
            }
        }

        RotationBike(steerAngle);
    }
    
    public void TurnRight(float inputX)
    {
        var steerAngle = 0.0f;
        foreach (var wheel in wheels)
        {
            if (wheel.axel == Axel.Front)
            {
                wheel.collider.steerAngle = Mathf.Clamp(inputX, -1, 1) * maxSteerAngle;
                steerAngle = wheel.collider.steerAngle;
            }
        }
        RotationBike(steerAngle);
    }

    public void Turn(float inputX)
    {
        foreach (var wheel in wheels)
        {
            if (wheel.axel == Axel.Front)
            {
                if (inputX > 0)
                    TurnRight(inputX);
                else if (inputX < 0)
                    TurnLeft(inputX);
                
            }
        }
    }

    public void RotationBike(float steerAngle)
    {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y,
            -steerAngle * 0.5f);
    }

    public List<Wheel> GetWheels()
    {
        return wheels;
    }

    public float GetSpeed()
    {
        return m_curSpeed;
    }

    public void pickUp()
    {
        Transform t = GetComponent<Transform>();
        t.position = t.position + new Vector3(0, 0.2f, 0);
        t.rotation = new Quaternion(0, 0, 0, 1);
    }

    public MotorInput WheelUpdate(MotorInput input)
    {
        curTrans = transform;
        var speed = (curTrans.position - prevTrans.position) / Time.deltaTime;

        m_curSpeed = speed.magnitude;
        prevTrans = curTrans;

        speedVal = speed.magnitude;
        var moveForward = speed.normalized;

        var angle = Vector3.Dot(moveForward, Vector3.Cross(transform.up, new Vector3(0, 1, 0)));
        var omega = (angle - prevAngle) / Time.fixedDeltaTime;
        prevAngle = angle;
        prevOmega = omega;

        float lowSpeed = 8f;
        float highSpeed = 25f;

        if (speedVal < lowSpeed)
        {
            float t = speedVal / lowSpeed;
            input.steer *= t * t;
            omega *= t * t;
            angle = angle * (2 - t);
            input.acceleration += Mathf.Abs(angle) * 3 * (1 - t);
        }

        if (speedVal > highSpeed)
        {
            float t = speedVal / highSpeed;
            if (omega * angle < 0f)
            {
                omega *= t;
            }
        }

        input.steer *= (1 - 2.5f * angle * angle);

        input.steer = 1f / (speed.sqrMagnitude + 1f) * (input.steer * steerSensivity + angle * controlAngle + omega * controlOmega);
        float steerDelta = 10 * Time.fixedDeltaTime;
        input.steer = Mathf.Clamp(input.steer, prevSteer - steerDelta, prevSteer + steerDelta);
        prevSteer = input.steer;

        return input;
    }

    private void updateWheels()
    {
        float delta = Time.fixedDeltaTime;

        foreach (Wheel w in wheels)
        {
            WheelHit hit;

            Vector3 localPos = w.model.transform.localPosition;
            if (w.collider.GetGroundHit(out hit))
            {
                localPos.y -= Vector3.Dot(w.model.transform.position - hit.point, transform.up) - w.collider.radius;
                w.model.transform.localPosition = localPos;
            }
            else
            {
                //localPos.y = w.wheelStartPos.y - wheelOffset;
            }
            //w.wheelTransform.localPosition = localPos;

            //w.model.transform.rotation = Mathf.Repeat(w.rotation + delta * w.collider.rpm * 360.0f / 60.0f, 360f);
            w.model.transform.localRotation = Quaternion.Euler(w.rotation, w.collider.steerAngle, 90.0f);
        }
    }
}
