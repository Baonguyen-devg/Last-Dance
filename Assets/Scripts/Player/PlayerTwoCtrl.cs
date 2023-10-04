using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerTwoCtrl : MonoBehaviour
    {
        private PlayerTwoMovement playerTwoMovement;
        public PlayerTwoMovement GetPlayerMovement() => playerTwoMovement;

        private void Awake()
        {
            this.playerTwoMovement = GetComponent<PlayerTwoMovement>();
        }
    }
}