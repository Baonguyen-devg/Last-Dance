using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Balance thighBalance;
        [SerializeField] private Balance legBalance;
        [SerializeField] private Balance footBalance;
        
        private PlayerController playerController;

        private void Start()
        {
            playerController = GetComponent<PlayerController>();
            thighBalance = transform.Find("thigh").GetComponent<Balance>();
            legBalance = transform.Find("leg").GetComponent<Balance>();
            footBalance = transform.Find("foot").GetComponent<Balance>();
        }

        private void FixedUpdate()
        {
            if (!GameManager.Instance.IsGamePlaying()) return;
            if (!playerController.GetAbstractPlayerMovement().CanMove())
            {
                UpdateAnimation(false);
                return;
            }
            
            UpdateAnimation();
        }
        
        private void UpdateAnimation(bool isUpdate = true)
        {
            if (!isUpdate)
            {
                thighBalance.SetAnimation(false);
                legBalance.SetAnimation(false);
                footBalance.SetAnimation(false);
                return;
            }
            
            AbstractPlayerMovement abstractPlayerMovement = playerController.GetAbstractPlayerMovement();

            thighBalance.SetAnimation(abstractPlayerMovement.GetUpKey());
            legBalance.SetAnimation(abstractPlayerMovement.GetLeftKey() || abstractPlayerMovement.GetRightKey());
            footBalance.SetAnimation(abstractPlayerMovement.GetUpKey());
        }
    }
}