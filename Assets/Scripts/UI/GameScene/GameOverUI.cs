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
        
        private void Start()
        {
            playerWinText.gameObject.SetActive(false);
            GameManager.Instance.OnGameOver += GameManager_OnGameOver;
        }

        private void GameManager_OnGameOver(object sender, EventArgs e)
        {
            playerWinText.gameObject.SetActive(true);
            string winner = ScoreManager.Instance.IsPlayerOneMaxScore() ? "PLAYER ONE" : "PLAYER TWO";
            Debug.Log(ScoreManager.Instance.IsPlayerOneMaxScore() + " HERE");
            playerWinText.text = winner + " WIN";
        }
    }
}