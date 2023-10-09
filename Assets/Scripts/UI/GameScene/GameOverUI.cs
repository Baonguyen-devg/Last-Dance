using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace.UI.GameScene
{
    public class GameOverUI : AutoMonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI playerWinText;

        [ContextMenu("Load Component")]
        protected override void LoadComponent() =>
            this.playerWinText = transform.GetComponentInChildren<TextMeshProUGUI>();

        private void OnEnable() => this.OnGameOver();

        private void OnGameOver()
        {
            string winner = ScoreManager.Instance.IsPlayerOneMaxScore() ? "PLAYER ONE" : "PLAYER TWO";
            playerWinText.text = winner + " WIN";
        }
    }
}