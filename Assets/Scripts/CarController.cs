using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private float steerangle;

    public WheelCollider cFrontL, cFrontR, cBackL, cBackR;
    public Transform tFrontL, tFrontR, tBackL, tBackR;

    public float speed;
    private float MaxSteerAngle = 30;

    void GetInput()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    void Steer()
    {
        steerangle = MaxSteerAngle * horizontal;
        cFrontL.steerAngle = steerangle;
        cFrontR.steerAngle = steerangle;
    }

    void accelerate()
    {
        cBackL.motorTorque = vertical * speed;
        cBackR.motorTorque = vertical * speed;
    }

    void UpdateWheelPose()
    {
        UpdateWheelPose(cFrontR, tFrontR);
        UpdateWheelPose(cFrontL, tFrontL);
        UpdateWheelPose(cBackR, tBackR);
        UpdateWheelPose(cBackL, tBackL);
    }

    void UpdateWheelPose(WheelCollider ctire,Transform tire)
    {
        Vector3 position = tire.position;
        Quaternion quart = tire.rotation;

        ctire.GetWorldPose(out position, out quart);

        tire.position = position;
        tire.rotation = quart;
    }

    private void FixedUpdate()
    {
        GetInput();
        accelerate();
        Steer();
        UpdateWheelPose();
    }
}
