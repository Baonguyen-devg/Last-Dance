using UnityEngine;

namespace DefaultNamespace
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform targetTransform;
        [SerializeField] private float smoothnessRand = 10;
        
        private void LateUpdate() => SmoothFollow();

        private void SmoothFollow()
        {
            float distanceX = transform.position.x - targetTransform.position.x;
            if (CalculateAbsolute(distanceX) < smoothnessRand) return;
            transform.position = GetNewPosition(distanceX);
        }

        private float CalculateAbsolute(float value) => value >= 0 ? value : -value;

        private Vector3 GetNewPosition(float distanceX)
        {
            Vector3 newPosition = transform.position;
            newPosition.x = targetTransform.position.x;
            newPosition.x += distanceX > 0 ? smoothnessRand : -smoothnessRand;
            return newPosition;
        }
    }
}