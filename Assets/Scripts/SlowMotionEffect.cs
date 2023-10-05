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
                return;
            }
            
            if (IsWarning() && !isSlowMotion)
            {
                isSlowMotion = true;
                //StartCoroutine(ChangeTimeScale(timeScaleSlowMotion));
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

        // private IEnumerator ChangeTimeScale(float targetTimeScale)
        // {
        //     float startScale = Time.timeScale;
        //     float startTime = Time.time;
        //     float elapsedTime = 0f;
        //     float transitionDuration = 0.2f; // Thời gian chuyển đổi
        //
        //     while (elapsedTime < transitionDuration)
        //     {
        //         float t = elapsedTime / transitionDuration;
        //         Time.timeScale = Mathf.Lerp(startScale, targetTimeScale, t);
        //         elapsedTime = Time.time - startTime;
        //         yield return null;
        //     }
        //
        //     Time.timeScale = targetTimeScale;
        // }
    }
}