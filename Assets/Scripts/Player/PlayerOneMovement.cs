using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerOneMovement : AbstractPlayerMovement
    {
        protected override bool GetLeftKey() => InputManager.Instance.IsAPressed();
        protected override bool GetUpKey() => InputManager.Instance.IsWPressed();
        protected override bool GetRightKey() => InputManager.Instance.IsDPressed();

        protected override Vector3 GetForceDirection(float targetRotationEuler) 
            => Quaternion.Euler(0f, 0f, targetRotationEuler) * (Vector2.up + Vector2.right);

        protected override void MoveToLeft(Vector2 forceDirection)
        {
            headRigidBody2D.velocity = forceDirection.normalized * forcePush;
            float thighVelocity = outSideVelocityRate * forcePush;
            thighBody2D.velocity = Vector2.left * thighVelocity;
        }

        protected override void MoveUp(float targetRotationEuler)
        {
            Vector3 forceDirection = Quaternion.Euler(0f, 0f, targetRotationEuler) * Vector2.up;
            headRigidBody2D.velocity = forceDirection.normalized * forcePush;
            forceDirection = Quaternion.Euler(0f, 0f, targetRotationEuler) * Vector2.left;
            thighBody2D.velocity = forceDirection.normalized * forcePush;
        }

        protected override void MoveToRight(Vector2 forceDirection) 
            => headRigidBody2D.velocity = forceDirection.normalized * forcePush;
    }
}