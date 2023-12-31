using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerTwoMovement : AbstractPlayerMovement
    {
        public override bool GetLeftKey() => InputManager.Instance.IsLeftArrowPressed();
        public override bool GetUpKey() => InputManager.Instance.IsUpArrowPressed();
        public override bool GetRightKey() => InputManager.Instance.IsRightArrowPressed();

        protected override Vector3 GetForceDirection(float targetRotationEuler) 
            => Quaternion.Euler(0f, 0f, targetRotationEuler) * (Vector2.up + Vector2.left);

        protected override void MoveToLeft(Vector2 forceDirection) 
            => headRigidBody2D.velocity = forceDirection.normalized * forcePush;

        protected override void MoveUp(float targetRotationEuler)
        {
            Vector3 forceDirection = Quaternion.Euler(0f, 0f, targetRotationEuler) * Vector2.up;
            headRigidBody2D.velocity = forceDirection.normalized * forcePush;
            forceDirection = Quaternion.Euler(0f, 0f, targetRotationEuler) * Vector2.right;
            thighBody2D.velocity = forceDirection.normalized * forcePush;
        }

        protected override void MoveToRight(Vector2 forceDirection)
        {
            headRigidBody2D.velocity = forceDirection.normalized * forcePush;
            float thighVelocity = outSideVelocityRate * forcePush;
            thighBody2D.velocity = Vector2.right * thighVelocity;
        }
    }
}