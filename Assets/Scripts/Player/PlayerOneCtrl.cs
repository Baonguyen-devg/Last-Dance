using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerOneCtrl : MonoBehaviour
    {
        private PlayerOneMovement playerOneMovement;
        public PlayerOneMovement GetPlayerMovement() => playerOneMovement;

        private void Awake()
        {
            this.playerOneMovement = GetComponent<PlayerOneMovement>();
        }
    }
}