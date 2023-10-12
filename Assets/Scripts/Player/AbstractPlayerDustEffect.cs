using System;
using UnityEngine;

namespace DefaultNamespace
{
    public abstract class AbstractPlayerDustEffect : MonoBehaviour
    {
        [SerializeField] protected GroundCheck groundCheck;
        
        protected Transform footPSRightTransform;
        protected Transform footPSUpTransform;
        protected Transform footPSLeftTransform;

        private void Start()
        {
            footPSRightTransform = EffectPoolingObject.Instance.GetPrefabList()[0];
            footPSUpTransform = EffectPoolingObject.Instance.GetPrefabList()[1];
            footPSLeftTransform = EffectPoolingObject.Instance.GetPrefabList()[2];
        }

        protected virtual void LateUpdate()
        {
            if (!GameManager.Instance.IsGamePlaying() || !groundCheck.IsGround()) return;

            if (GetKeyRightDown()) CreateParticle(footPSRightTransform);

            if (GetKeyUpDown()) CreateParticle(footPSUpTransform);

            if (GetKeyLeftDown()) CreateParticle(footPSLeftTransform);
        }

        protected abstract bool GetKeyLeftDown();
        protected abstract bool GetKeyUpDown();
        protected abstract bool GetKeyRightDown();

        protected virtual void CreateParticle(Transform particlePrefab)
        {
            Transform footPS = EffectPoolingObject.Instance.GetTransform(particlePrefab);
            footPS.position = groundCheck.GetHitPoint();
            footPS.gameObject.SetActive(true);
        }   
    }
}