using DefaultNamespace;
using UnityEngine;

public class BigHandController : MonoBehaviour
{
    [SerializeField] private PlayerOneCtrl playerOneCtrl;
    [SerializeField] private PlayerTwoCtrl playerTwoCtrl;
    private Rigidbody2D rigidbody2D;

    private void Start() => rigidbody2D = GetComponent<Rigidbody2D>();

    private void FixedUpdate() => GravityControl();

    private void GravityControl()
    {
        float scale = transform.position.y;
        rigidbody2D.mass = scale >= 1 ? scale * 6f : 3;
        rigidbody2D.gravityScale = scale >= 1 ? scale * 4f : 3;
        //rigidbody2D.mass = IsHasControl() ? scale * 5f : 3;
        //rigidbody2D.gravityScale = IsHasControl() ? scale * 2f : 3;
    }

    private bool IsHasControl()
    {
        return playerOneCtrl.GetPlayerMovement().IsHasInput() 
               || playerTwoCtrl.GetPlayerMovement().IsHasInput();
    }
}
