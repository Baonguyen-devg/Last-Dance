using UnityEngine;

namespace DefaultNamespace
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform targetTransform;
        [SerializeField] private float smoothnessRand = 10;
        [SerializeField] private float smoothnessSpeedMin = 1;
        [SerializeField] private float smoothnessSpeedMax = 6;
        
        //CameraZoom with field of view
        // private Camera camera;
        //
        // private void Start()
        // {
        //     camera = GetComponent<Camera>();
        // }

        private void LateUpdate()
        {
            Vector3 targetPosition = targetTransform.position;
            targetPosition.y = 0;
            targetPosition.z = transform.position.z;
            
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * GetSmoothTime());
        }

        public float GetSmoothTime()
        {
            float distanceX = Mathf.Abs(transform.position.x - targetTransform.position.x);
            float smoothTime = distanceX / smoothnessRand;
            return Mathf.Clamp(smoothTime, smoothnessSpeedMin, smoothnessSpeedMax); 
        }
    }
}