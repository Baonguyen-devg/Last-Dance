using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerController : RepeatMonoBehaviour 
    {
        [SerializeField] private AbstractPlayerMovement abstractPlayerMovement;
        [SerializeField] private PlayerStamina playerStamina;

        protected override void LoadComponents()
        {
            base.LoadComponents();
            abstractPlayerMovement = GetComponent<AbstractPlayerMovement>();
            playerStamina = GetComponent<PlayerStamina>();
        }

        public AbstractPlayerMovement GetAbstractPlayerMovement() => abstractPlayerMovement; 
        
        public PlayerStamina GetPlayerStamina() => playerStamina; 
    }
}