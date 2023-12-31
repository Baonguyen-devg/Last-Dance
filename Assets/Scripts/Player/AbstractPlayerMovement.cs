using System;
using UnityEngine;

namespace DefaultNamespace
{
    public abstract class AbstractPlayerMovement : MonoBehaviour
    {
        [SerializeField] protected float forcePush;
        [SerializeField] protected HingeControl hingeControl;
        [SerializeField] protected Rigidbody2D headRigidBody2D;
        [SerializeField] protected Transform headTransform;
        [SerializeField] protected Rigidbody2D thighBody2D;
        [SerializeField] protected float outSideVelocityRate = 2;

        protected PlayerController playerController;
        protected bool canMove;

        private void Awake() => playerController = GetComponent<PlayerController>();

        private void Start() => hingeControl.SetIsTurnOnMotorAndLimit(true);

        private void FixedUpdate()
        {
            canMove = false;
            
            if (GameManager.Instance.IsOnePlayerDead())
            {
                hingeControl.SetIsTurnOnMotorAndLimit(false);
                return;
            }
            
            if(!GameManager.Instance.IsGamePlaying()) return;
            if(playerController.GetPlayerStamina().IsPassive()) return;
            
            Move();   
        }
        
        protected virtual void Move()
        {
            bool isLeftKeyPressed = GetLeftKey();
            bool isUpKeyPressed = GetUpKey();
            bool isRightKeyPressed = GetRightKey();
            bool isPress = isLeftKeyPressed || isUpKeyPressed || isRightKeyPressed;
            canMove = isPress;
            
            if (!isPress) { ResetValueAndState(); return;}

            hingeControl.SetIsTurnOnMotorAndLimit(true);

            Quaternion targetRotation = headTransform.localRotation;
            float targetRotationEuler = targetRotation.eulerAngles.z;
            Vector2 forceDirection = GetForceDirection(targetRotationEuler);

            if (isLeftKeyPressed) MoveToLeft(forceDirection);
            if (isUpKeyPressed) MoveUp(targetRotationEuler);
            if (isRightKeyPressed) MoveToRight(forceDirection);
            
            if (!isLeftKeyPressed && !isRightKeyPressed)
                hingeControl.SetIsTurnOnMotorAndLimit(false);
            
            if(isLeftKeyPressed || isRightKeyPressed) hingeControl.SetMotor(0, 0);
        }

        public abstract bool GetLeftKey();
        public abstract bool GetUpKey();
        public abstract bool GetRightKey();

        private void ResetValueAndState()
        {
            hingeControl.SetIsTurnOnMotorAndLimit(false);
            hingeControl.SetMotor(0, 0);
            hingeControl.IncreaseAngle(0);
            headRigidBody2D.velocity = Vector2.zero;
            thighBody2D.velocity = Vector2.zero;
        }

        protected abstract Vector3 GetForceDirection(float targetRotationEuler);

        protected abstract void MoveToLeft(Vector2 forceDirection);
        protected abstract void MoveUp(float targetRotationEuler);
        protected abstract void MoveToRight(Vector2 forceDirection);

        public bool CanMove() => canMove;
    }
}