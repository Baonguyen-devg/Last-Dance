using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class SlowMotionEffect : MonoBehaviour
    {
        //Dat
        [SerializeField] private float slowMotionFactor = 0.05f;

        private bool isSlowMotion;

        private void Awake() => isSlowMotion = false;

        private void LateUpdate()
        {
            if (!GameManager.Instance.IsGamePlaying())
            {
                SetDefaultTimes();
                isSlowMotion = true;
                return;
            }
            
            if (IsWarning() && !isSlowMotion)
            {
                isSlowMotion = true;
                DoSlowMotion();
            }

            if (!IsWarning())
            {
                SetDefaultTimes();
                isSlowMotion = false;
            }
        }

        private static void SetDefaultTimes()
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f;
        }

        private bool IsWarning()
        {
            HeadPositionChecker headPositionChecker = HeadPositionChecker.Instance;
            return headPositionChecker.IsHeadOneWarning() 
                   || headPositionChecker.IsHeadTwoWarning();
        }

        private void DoSlowMotion()
        {
            Time.timeScale = slowMotionFactor;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }
    }
}