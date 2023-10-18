using UnityEngine;

namespace DefaultNamespace
{
    public class EffectHeadSmokeTail : MonoBehaviour
    {
        [SerializeField] private float spawnRate = 1.0f;
        
        private bool isSmoke = false;
        private float timer;

        public void Smoke() => isSmoke = true;

        private void FixedUpdate()
        {
            if (!isSmoke) return;
            
            timer += Time.fixedDeltaTime;
            if (timer < spawnRate) return;
            SpawnSmoke();
            timer = 0;
        }

        private void SpawnSmoke()
        {
            Transform smoke = EffectPoolingObject.Instance.GetTransformByIndex(4);
            smoke.position = transform.position;
        }
    }
}