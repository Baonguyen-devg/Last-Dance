using UnityEngine;

namespace DefaultNamespace
{
    public class StarStun : MonoBehaviour
    {
        [SerializeField] float rotationSpeed = 180.0f; 
        
        private SpriteRenderer spriteRenderer;

        private void Start()
        {
            rotationSpeed = Random.Range(-rotationSpeed, rotationSpeed);
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void FixedUpdate()
        {
            Rotate();
            UpdateLayerOrder();
        }

        private void Rotate() 
            => transform.Rotate(Vector3.forward, rotationSpeed * Time.fixedDeltaTime);

        private void UpdateLayerOrder() => spriteRenderer.sortingOrder = GetSortingOrder();

        private int GetSortingOrder() => transform.position.z < 0 ? 11 : 13;
    }
}