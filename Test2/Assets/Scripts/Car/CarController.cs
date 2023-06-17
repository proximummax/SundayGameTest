using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float _rotateInput;
    private float _moveInput;
    private float _currentSteerAngle;

    [SerializeField] private float motorForce, breakForce, maxSteerAngle;

    [SerializeField] private WheelCollider _frontLeftWheelCollider, _frontRightWheelCollider, _rearLeftWheelCollider, _rearRightWheelCollider;

    [SerializeField] private Transform _frontLeftWheelTransform, _frontRightWheelTransform, _rearLeftWheelTransform, _rearRightWheelTransform;

    private void FixedUpdate()
    {
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }
    public void MoveInput(float Input)
    {
        _moveInput = Input;
    }
    public void RotateInput(float Input)
    {
        _rotateInput += Input;
    }

    private void HandleMotor()
    {
        _frontLeftWheelCollider.motorTorque = _moveInput * motorForce;
        _frontRightWheelCollider.motorTorque = _moveInput * motorForce;

    }

    private void HandleSteering()
    {
        _currentSteerAngle = maxSteerAngle * _rotateInput;
        if (Mathf.Abs(_currentSteerAngle) > maxSteerAngle)
            return;
        _frontLeftWheelCollider.steerAngle = _currentSteerAngle;
        _frontRightWheelCollider.steerAngle = _currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(_frontLeftWheelCollider, _frontLeftWheelTransform);
        UpdateSingleWheel(_frontRightWheelCollider, _frontRightWheelTransform);
        UpdateSingleWheel(_rearRightWheelCollider, _rearRightWheelTransform);
        UpdateSingleWheel(_rearLeftWheelCollider, _rearLeftWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        wheelCollider.GetWorldPose(out Vector3 position, out Quaternion rotation);

        wheelTransform.rotation = rotation;
        wheelTransform.position = position;
    }
}
