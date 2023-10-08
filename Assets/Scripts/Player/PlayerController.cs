using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerController : MonoBehaviour {
        [SerializeField] private AbstractPlayerMovement abstractPlayerMovement;
        [SerializeField] private PlayerStamina playerStamina;
        [SerializeField] private PlayerAnimation playerAnimation;

        private void Awake()
        {
            abstractPlayerMovement = GetComponent<AbstractPlayerMovement>();
            playerStamina = GetComponent<PlayerStamina>();
            playerAnimation = GetComponent<PlayerAnimation>();
        }

        public AbstractPlayerMovement GetAbstractPlayerMovement() => abstractPlayerMovement; 
        
        public PlayerStamina GetPlayerStamina() => playerStamina; 

        public PlayerAnimation GetPlayerAnimation() => playerAnimation; 
    }
}