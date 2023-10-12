using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class CameraAnimation : MonoBehaviour
    {
        private Animator animator;

        private const string IS_SHAKE = "isShake";
        
        private void Start() => animator = GetComponent<Animator>();

        public void Shake() => animator.SetTrigger(IS_SHAKE);
    }
}