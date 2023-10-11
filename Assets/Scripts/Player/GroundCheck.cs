using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float distance; 

    private bool isGrounded;
    private Vector2 hitPoint;

    private void Update()
    {
        if (!GameManager.Instance.IsGamePlaying()) return;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distance,groundLayer);
        isGrounded = hit.collider != null;
        hitPoint = isGrounded ? hit.point: Vector2.zero;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - distance, transform.position.z));
    }
    
    public bool IsGround() => isGrounded;

    public Vector2 GetHitPoint() => hitPoint;
}