using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Balance : MonoBehaviour
{
    [SerializeField] private float targetRotation;
    [SerializeField] private float targetRotationAnimaiton;
    [SerializeField] private float rotationForce;
    
    private new Rigidbody2D rigidbody2D;
    private float defaultTargetRotation;
    
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        defaultTargetRotation = targetRotation;
    }

    private void FixedUpdate() => BalanceToTargetRotation();

    private void BalanceToTargetRotation()
    {
        float currentRotation = rigidbody2D.rotation;
        float newRotation = Mathf.LerpAngle(currentRotation, targetRotation, rotationForce * Time.fixedDeltaTime);
        rigidbody2D.MoveRotation(newRotation);
    }

    public void SetAnimation(bool isOn) 
        => targetRotation = isOn ? targetRotationAnimaiton : defaultTargetRotation;
}