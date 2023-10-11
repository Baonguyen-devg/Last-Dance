using System;
using RepeatUtil.DesignPattern.SingletonPattern;
using UnityEngine;

namespace DefaultNamespace
{
    public class InputManager : Singleton<InputManager>
    {
        public event EventHandler OnPauseAction;
        
        private bool isAPressed;
        private bool isDPressed;
        private bool isWPressed;
        private bool isLeftArrowPressed;
        private bool isUpArrowPressed;
        private bool isRightArrowPressed;
        
        private bool isADown;
        private bool isDDown;
        private bool isWDown;
        private bool isLeftArrowDown;
        private bool isUpArrowDown;
        private bool isRightArrowDown;

        private void Update()
        {
            isAPressed = Input.GetKey(KeyCode.A);
            isDPressed = Input.GetKey(KeyCode.D);
            isWPressed = Input.GetKey(KeyCode.W);
            isLeftArrowPressed = Input.GetKey(KeyCode.LeftArrow);
            isUpArrowPressed = Input.GetKey(KeyCode.UpArrow);
            isRightArrowPressed = Input.GetKey(KeyCode.RightArrow);
      
            isADown = Input.GetKeyDown(KeyCode.A);
            isDDown = Input.GetKeyDown(KeyCode.D);
            isWDown = Input.GetKeyDown(KeyCode.W);
            isLeftArrowDown = Input.GetKeyDown(KeyCode.LeftArrow);
            isUpArrowDown = Input.GetKeyDown(KeyCode.UpArrow);
            isRightArrowDown = Input.GetKeyDown(KeyCode.RightArrow);
            
            if (Input.GetKeyDown(KeyCode.Escape)) 
                this.OnPauseAction?.Invoke(null, EventArgs.Empty);
        }

        public bool IsAPressed() => isAPressed;

        public bool IsDPressed() => isDPressed;

        public bool IsWPressed() => isWPressed;

        public bool IsLeftArrowPressed() => isLeftArrowPressed;

        public bool IsUpArrowPressed() => isUpArrowPressed;

        public bool IsRightArrowPressed() => isRightArrowPressed;
        
        public bool IsADown() => isADown;

        public bool IsDDown() => isDDown;

        public bool IsWDown() => isWDown;

        public bool IsLeftArrowDown() => isLeftArrowDown;

        public bool IsUpArrowDown() => isUpArrowDown;

        public bool IsRightArrowDown() => isRightArrowDown;
    }
}