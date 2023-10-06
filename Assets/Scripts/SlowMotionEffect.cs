using UnityEngine;

namespace DefaultNamespace
{
    public class SlowMotionEffect : MonoBehaviour
    {
        //Dat
        [SerializeField] private float slowMotionFactor = 0.05f;

        private bool isSlowMotion = false;
        
        private void LateUpdate()
        {
            if (!GameManager.Instance.IsGamePlaying())
            {
                Time.timeScale = 1;
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
                Time.timeScale = 1;
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