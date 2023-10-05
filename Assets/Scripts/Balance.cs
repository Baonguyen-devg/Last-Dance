using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Balance : MonoBehaviour
{
    [SerializeField] private float targetRotation;
    [SerializeField] private float rotationForce;

    private new Rigidbody2D rigidbody2D;

    private void Start() => rigidbody2D = GetComponent<Rigidbody2D>();

    private void FixedUpdate() => BalanceToTargetRotation();

    private void BalanceToTargetRotation()
    {
        float currentRotation = rigidbody2D.rotation;
        float newRotation = Mathf.LerpAngle(currentRotation, targetRotation, rotationForce * Time.fixedDeltaTime);
        rigidbody2D.MoveRotation(newRotation);
    }
}