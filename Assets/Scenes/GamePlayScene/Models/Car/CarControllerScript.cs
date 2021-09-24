using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControllerScript : MonoBehaviour
{
    private float m_horizontalInput;
    private float m_verticalInput;
    private float m_steeringAngle;

    public WheelCollider FRWheel, FLWheel;
    public WheelCollider BRWheel, BLWheel;
    public Transform FRWheelTransform, FLWheelTransform;
    public Transform BRWheelTransform, BLWheelTransform;
    public float maxSteerAngle = 30;
    public float motorForce = 50;
    
    // Speed Check
    private Vector3 prevTrans;
    private Vector3 curTrans;
    private float m_curSpeed;

    public void GetInput()
    {
        m_horizontalInput = Input.GetAxis("Horizontal");
        m_verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Space))
            QuickBrake();
        else
            Idle();
    }
    
    private void Idle()
    {
        if(FLWheel.brakeTorque  > 0 || FRWheel.brakeTorque > 0)
        {
            FLWheel.brakeTorque = 0;
            FRWheel.brakeTorque = 0;
            BLWheel.brakeTorque = 0;
            BRWheel.brakeTorque = 0;
        }
    }

    private void QuickBrake()
    {
        FLWheel.brakeTorque = motorForce * 2;
        FRWheel.brakeTorque = motorForce * 2;
        BLWheel.brakeTorque = motorForce * 2;
        BRWheel.brakeTorque = motorForce * 2;
    }

    private void Brake(float brake)
    {
        FLWheel.brakeTorque = motorForce * brake;
        FRWheel.brakeTorque = motorForce * brake;
    }

    private void Steer()
    {
        m_steeringAngle = maxSteerAngle * m_horizontalInput;
        FLWheel.steerAngle = m_steeringAngle;
        FRWheel.steerAngle = m_steeringAngle;
    }

    private void Accelerate()
    {
        FLWheel.motorTorque = -m_verticalInput * motorForce;
        FRWheel.motorTorque = -m_verticalInput * motorForce;

        if (FLWheel.motorTorque < -motorForce)
        {
            FLWheel.motorTorque = -motorForce;
            FRWheel.motorTorque = -motorForce;
        }
    }

    private void UpdateWheelPoses()
    {
        UpdateWheelPose(FRWheel, FRWheelTransform);
        UpdateWheelPose(FLWheel, FLWheelTransform);
        UpdateWheelPose(BRWheel, BRWheelTransform);
        UpdateWheelPose(BLWheel, BLWheelTransform);
    }
    
    private void UpdateWheelPose(WheelCollider collider, Transform transform)
    {
        //transform.Rotate(new Vector3(0, -90, 0));
        Vector3 pos;
        Quaternion quat;

        collider.GetWorldPose(out pos, out quat);

        transform.position = pos;
        transform.rotation = quat;

        // 현 타이어가 90도로 회전되어 있음
        transform.Rotate(new Vector3(0, -90, 0));
    }

    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPoses();
    }

    private void Update()
    {
        // Speed Update
        curTrans = transform.position;
        var speed = (curTrans - prevTrans) / Time.deltaTime;

        //Debug.Log("curTrans: " + curTrans);
        //Debug.Log("prevTrans: " + prevTrans);

        m_curSpeed = speed.magnitude;
        prevTrans = curTrans;

        //Debug.Log("m_curSpeed: " + m_curSpeed);
    }

    // Start is called before the first frame update
    void Start()
    {
        prevTrans = transform.position;
        curTrans = transform.position;
    }


    public float GetSpeed()
    {
        return m_curSpeed;
    }

    public float GetVelocity()
    {
        float KPH;
        Rigidbody rigidbody = GameObject.Find("Car").GetComponent<Rigidbody>();
        KPH = rigidbody.velocity.magnitude * 3.6f;
        return KPH;
    }
}
