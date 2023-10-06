using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Balance thighBalance;
        [SerializeField] private Balance legBalance;
        [SerializeField] private Balance footBalance;
        
        private AbstractPlayerMovement abstractPlayerMovement;
        
        private void Start()
        {
            abstractPlayerMovement = GetComponent<AbstractPlayerMovement>();
            thighBalance = transform.Find("thigh").GetComponent<Balance>();
            legBalance = transform.Find("leg").GetComponent<Balance>();
            footBalance = transform.Find("foot").GetComponent<Balance>();
        }

        private void FixedUpdate()
        {
            if (!GameManager.Instance.IsGamePlaying()) return;
            SetAnimation();
        }

        private void SetAnimation()
        {
            thighBalance.SetAnimation(abstractPlayerMovement.GetUpKey());
            legBalance.SetAnimation(abstractPlayerMovement.GetLeftKey() || abstractPlayerMovement.GetRightKey());
            footBalance.SetAnimation(abstractPlayerMovement.GetUpKey());
        }
    }
}