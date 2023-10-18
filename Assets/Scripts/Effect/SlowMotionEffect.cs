using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class SlowMotionEffect : MonoBehaviour
    {
        //Dat
        [SerializeField] private float slowMotionFactor = 0.05f;
        
        private bool isSlowMotion = false;
        private bool isFinishSlowMotionEndGame = false;
        private float timeSlowMotionEndGame = 0.5f;
        
        private void LateUpdate()
        {
            if (isFinishSlowMotionEndGame)
            {
                TimeManager.Instance.ResetToDefaultTimes();
                return;
            }

            if (ScoreManager.Instance.IsOnePlayerMaxScore())
            {
                DoSlowMotion();
                timeSlowMotionEndGame -= Time.fixedDeltaTime;
                if (timeSlowMotionEndGame <= 0) 
                    isFinishSlowMotionEndGame = true;
                return;
            }

            if (GameManager.Instance.IsGamePause()) return;
            if (!GameManager.Instance.IsGamePlaying())
            {
                TimeManager.Instance.ResetToDefaultTimes();
                return;
            }

            HandleSlowMotion();
        }


        private void HandleSlowMotion()
        {
            if (IsWarning() && !isSlowMotion)
            {
                isSlowMotion = true;
                DoSlowMotion();
            }

            if (!IsWarning())
            {
                TimeManager.Instance.ResetToDefaultTimes();
                isSlowMotion = false;
            }
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