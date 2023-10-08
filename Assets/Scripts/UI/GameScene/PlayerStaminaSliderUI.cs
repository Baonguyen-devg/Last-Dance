using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.UI.GameScene
{
    public class PlayerStaminaSliderUI : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;
        
        private Slider slider;

        private void Start()
        {
            slider = GetComponent<Slider>();
            slider.value = playerController.GetPlayerStamina().GetCurrentValuePerDefaultValue();
        }

        private void LateUpdate()
        {
            UpdateSliderValue();
        }

        public void UpdateSliderValue()
        {
            slider.value = playerController.GetPlayerStamina().GetCurrentValuePerDefaultValue();
        }
    }
}