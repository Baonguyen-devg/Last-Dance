using System;
using RepeatUtil.DesignPattern.SingletonPattern;
using UnityEngine;

namespace DefaultNamespace
{
    public class InputManager : Singleton<InputManager>
    {
        public event EventHandler OnPauseAction;
        
        private bool isAPressed = false;
        private bool isDPressed = false;
        private bool isWPressed = false;
        private bool isLeftArrowPressed = false;
        private bool isUpArrowPressed = false;
        private bool isRightArrowPressed = false;

        private void Update()
        {
            isAPressed = Input.GetKey(KeyCode.A);
            isDPressed = Input.GetKey(KeyCode.D);
            isWPressed = Input.GetKey(KeyCode.W);
            isLeftArrowPressed = Input.GetKey(KeyCode.LeftArrow);
            isUpArrowPressed = Input.GetKey(KeyCode.UpArrow);
            isRightArrowPressed = Input.GetKey(KeyCode.RightArrow);
      
            if (Input.GetKeyDown(KeyCode.Escape)) 
                this.OnPauseAction?.Invoke(null, EventArgs.Empty);
        }

        public bool IsAPressed() => isAPressed;

        public bool IsDPressed() => isDPressed;

        public bool IsWPressed() => isWPressed;

        public bool IsLeftArrowPressed() => isLeftArrowPressed;

        public bool IsUpArrowPressed() => isUpArrowPressed;

        public bool IsRightArrowPressed() => isRightArrowPressed;
    }
}