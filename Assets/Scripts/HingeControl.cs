using UnityEngine;

public class HingeControl : MonoBehaviour
{
    private HingeJoint2D hingeJoint;
    private JointAngleLimits2D limits;
    private bool isFlipping = false;
    [SerializeField] private float flipThreshold = 100f;
    private bool isTurnOnMotorAndLimit = false;
    
    
    private void Start()
    {
        hingeJoint = GetComponent<HingeJoint2D>();
        hingeJoint.useMotor = true;
        hingeJoint.useLimits = true;
        limits = hingeJoint.limits;
        defaultMotorSpeed = hingeJoint.motor.motorSpeed;
        defaultangleMin = hingeJoint.limits.min;
        defaultangleMax = hingeJoint.limits.max;
        defaultMaximumMotorForce = hingeJoint.motor.maxMotorTorque;
    }

    private void FixedUpdate()
    {
        if (isTurnOnMotorAndLimit)
        {
            ToggleMotorAndLimits(true);
            return;
        }
        
        float currentAngle = hingeJoint.jointAngle;
        bool beyondLimits = currentAngle < limits.min || currentAngle > limits.max;
        float rotationSpeed = Mathf.Abs(hingeJoint.motor.motorSpeed);
        
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

    private void ToggleMotorAndLimits(bool enable)
    {
        hingeJoint.useMotor = enable;
        hingeJoint.useLimits = enable;
    }
    
    public void SetIsTurnOnMotorAndLimit(bool isOn) => this.isTurnOnMotorAndLimit = isOn;
    
    private JointMotor2D motor;
    private JointAngleLimits2D angle;
    private float defaultMotorSpeed, defaultMaximumMotorForce;
    private float defaultangleMin, defaultangleMax;
    
    public void SetMotor(float motorSpeed, float maximumMotorForce)
    {
        motor = hingeJoint.motor;

        if (motorSpeed == 0 || maximumMotorForce == 0)
        {
            motor.motorSpeed = defaultMotorSpeed;
            motor.maxMotorTorque = defaultMaximumMotorForce;
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
        angle = hingeJoint.limits;
        
        if (anglePlusValue == 0) {
            angle.min = defaultangleMin;
            angle.max = defaultangleMax;
        }else {
            angle.min += anglePlusValue;
            angle.max += anglePlusValue;
        }
        
        hingeJoint.limits = angle;
    }
}