using DefaultNamespace;
using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    [SerializeField] private int staminaDefault = 100;
    [SerializeField] private int staminaInputUse = 1;
    [SerializeField] private int staminaRecoveryFactor = 2;

    private PlayerController playerController;
    private int currentStamina;
    private bool isPassive = false;
    private AbstractPlayerMovement abstractPlayerMovement;

    private void Awake()
    {
        currentStamina = staminaDefault;
        playerController = GetComponent<PlayerController>();
        abstractPlayerMovement = playerController.GetAbstractPlayerMovement();
    }


    private void FixedUpdate()
    {
        if (!GameManager.Instance.IsGamePlaying()) return;
        HandleRecovery();
    }

    private void HandleRecovery()
    {
        if (isPassive)
        {
            if (IsRecovered()) isPassive = false;
            else currentStamina += staminaInputUse * staminaRecoveryFactor;
        }
        else
        {
            if (IsInput())
            {
                if (IsRunOutStamina()) isPassive = true;
                else currentStamina -= staminaInputUse;
            }
            else
            {
                if (IsLowerDefaultStamina()) currentStamina += staminaInputUse;
                else currentStamina = staminaDefault;
            }
        }

        currentStamina = Mathf.Clamp(currentStamina, 0, staminaDefault);
    }
    
    private bool IsRecovered() => !IsLowerDefaultStamina();

    private bool IsLowerDefaultStamina() => currentStamina < staminaDefault;

    private bool IsInput()
    {
        return abstractPlayerMovement.GetLeftKey() 
               || abstractPlayerMovement.GetUpKey() 
               || abstractPlayerMovement.GetRightKey();
    }

    private bool IsRunOutStamina() => currentStamina <= 0;

    public bool IsPassive() => isPassive;

    public float GetCurrentValuePerDefaultValue() => (float)currentStamina / staminaDefault;
}
