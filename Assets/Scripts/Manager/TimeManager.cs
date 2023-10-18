using System;
using RepeatUtil.DesignPattern.SingletonPattern;
using UnityEngine;

namespace DefaultNamespace
{
    public class TimeManager : Singleton<TimeManager>
    {
        private const float DEFAULT_TIME_SCALE = 1.0f;
        private const float DEFAULT_FIXED_DELTA_TIME = 0.02f;
        
        private float currentTimeScale;
        private float currentFixedTimeScale;

        protected override void RemoveDuplicates()
        {
            if(instance != null) { Destroy(gameObject); return; }
            instance = this;
        }

        private void Start()
        {
            GameManager.Instance.OnGamePaused += GameManager_OnGamePaused;
            GameManager.Instance.OnGameUnpaused += GameManager_OnGameUnpaused;

            ResetToDefaultTimes();
        }
        
        public void ResetToDefaultTimes()
        {
            Time.timeScale = DEFAULT_TIME_SCALE;
            Time.fixedDeltaTime = DEFAULT_FIXED_DELTA_TIME;
        }

        private void GameManager_OnGamePaused(object sender, EventArgs e) => TimeFrozen();
        
        private void GameManager_OnGameUnpaused(object sender, EventArgs e) => SetToCurrentTimes();

        public void TimeFrozen()
        {
            currentTimeScale = Time.timeScale;
            Time.timeScale = 0;
        }

        private void SetToCurrentTimes() 
            => Time.timeScale = currentTimeScale;

        private void OnDestroy()
        {
            if (GameManager.Instance == null) return;
            GameManager.Instance.OnGamePaused -= GameManager_OnGamePaused;
            GameManager.Instance.OnGameUnpaused -= GameManager_OnGameUnpaused;
        }
    }
}