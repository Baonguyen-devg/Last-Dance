using UnityEngine;

namespace DefaultNamespace
{
    public class EffectDespawnByTime : MonoBehaviour
    {
        private float timeDespawn;

        private void Start() => timeDespawn = transform.GetComponent<ParticleSystem>().main.duration;

        private void OnEnable() => Invoke("Despawn", timeDespawn);

        private void Despawn() => EffectPoolingObject.Instance.Despawn(this.transform);
    }
}