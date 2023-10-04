using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform targetTransform;
        private float defaultYPosition;

        private void Start()
        {
            defaultYPosition = targetTransform.position.y;
        }
        
        private void LateUpdate()
        {
            Vector3 positionFollow = targetTransform.position;
            positionFollow.y = defaultYPosition;
            positionFollow.z = this.transform.position.z;
            this.transform.position = positionFollow;
        }
    }
}