using UnityEngine;

[RequireComponent(typeof(HingeJoint2D))]
public class HingeControl : MonoBehaviour
{
    [SerializeField] private float flipThreshold = 100f;

    private new HingeJoint2D hingeJoint;
    private JointAngleLimits2D defaultLimits;
    private JointMotor2D defaultMotor;
    private bool isFlipping = false;
    private bool isTurnOnMotorAndLimit = false;

    private void Start()
    {
        hingeJoint = GetComponent<HingeJoint2D>();

        defaultLimits = hingeJoint.limits;
        defaultMotor = hingeJoint.motor;

        ToggleMotorAndLimits(true);
    }

    private void FixedUpdate()
    {
        if (isTurnOnMotorAndLimit){ToggleMotorAndLimits(true); return;}

        float rotationSpeed = Mathf.Abs(hingeJoint.motor.motorSpeed);
        bool beyondLimits = IsBeyondLimits();

        if (rotationSpeed > flipThreshold && !isFlipping && beyondLimits)
        {
            isFlipping = true;
            ToggleMotorAndLimits(false);
        }

        if ((rotationSpeed < flipThreshold || !beyondLimits) && isFlipping)
        {
            isFlipping = false;
            ToggleMotorAndLimits(true);
        }
    }

    private bool IsBeyondLimits()
    {
        float currentAngle = hingeJoint.jointAngle;
        return currentAngle < defaultLimits.min || currentAngle > defaultLimits.max;
    }

    private void ToggleMotorAndLimits(bool enable)
    {
        hingeJoint.useMotor = enable;
        hingeJoint.useLimits = enable;

        if (enable)
        {
            // Khôi phục giới hạn và motor mặc định
            hingeJoint.limits = defaultLimits;
            hingeJoint.motor = defaultMotor;
        }
    }

    public void SetIsTurnOnMotorAndLimit(bool isOn)
    {
        isTurnOnMotorAndLimit = isOn;
    }

    public void SetMotor(float motorSpeed, float maximumMotorForce)
    {
        JointMotor2D motor = hingeJoint.motor;

        if (motorSpeed == 0 || maximumMotorForce == 0)
        {
            motor.motorSpeed = defaultMotor.motorSpeed;
            motor.maxMotorTorque = defaultMotor.maxMotorTorque;
        }
        else
        {
            motor.motorSpeed = motorSpeed;
            motor.maxMotorTorque = maximumMotorForce;
        }

        hingeJoint.motor = motor;
    }

    public void IncreaseAngle(float anglePlusValue)
    {
        JointAngleLimits2D angleLimits = hingeJoint.limits;

        if (anglePlusValue == 0)
        {
            angleLimits = defaultLimits;
        }
        else
        {
            angleLimits.min += anglePlusValue;
            angleLimits.max += anglePlusValue;
        }

        hingeJoint.limits = angleLimits;
    }
}
