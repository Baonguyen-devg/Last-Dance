using RepeatUtil.DesignPattern.ObjectPooling;
using UnityEngine;

namespace DefaultNamespace
{
    public class EffectPoolingObject : TransformListObjectPooling
    {
        public static EffectPoolingObject Instance { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            if(Instance != null) Debug.LogError("EffectPoolingObject is already initialized!");
            Instance = this;
        }

        public Transform GetTransformByIndex(int index) 
            => GetTransform(prefabList[index]);
    }
}