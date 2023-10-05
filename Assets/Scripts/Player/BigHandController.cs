using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BigHandController : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    private const float GRAVITY_COORDINATE_Y_LIMIT_MIN = 1F;
    private const float GRAVITY_COORDINATE_Y_LIMIT_MAX = 2F;
    private const float GRAVITY_NORMAL = 5F;
    private const float GRAVITY_RATE_OUT_LIMIT_MAX = 20F;
    
    private void Start() => rigidbody2D = GetComponent<Rigidbody2D>();

    private void FixedUpdate()
    {
        if (!GameManager.Instance.IsGamePlaying()) return;
        GravityControl();
    }

    private void GravityControl()
    {
        float gravityScale = CalculateGravityScale();
        rigidbody2D.mass = gravityScale;
        rigidbody2D.gravityScale = gravityScale;
    }

    private float CalculateGravityScale()
    {
        float newYPosition = Mathf.Max(transform.position.y, GRAVITY_COORDINATE_Y_LIMIT_MIN);
        return newYPosition < GRAVITY_COORDINATE_Y_LIMIT_MAX
            ? GRAVITY_NORMAL : newYPosition * GRAVITY_RATE_OUT_LIMIT_MAX;
    }
}