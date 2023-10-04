using UnityEngine;

public class Balance : MonoBehaviour
{
    [SerializeField] private float targetRotation;
    [SerializeField] private float force;
    private Rigidbody2D rigidbody2D;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {   
        rigidbody2D.MoveRotation(Mathf.LerpAngle(rigidbody2D.rotation, targetRotation, force * Time.fixedDeltaTime));
    }

    public void SetAngle(float targetRotation) => this.targetRotation = targetRotation;
}
