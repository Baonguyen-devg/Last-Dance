using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace.UI.GameScene
{
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI playerWinText;
        
        private void Start()
        {
            playerWinText.gameObject.SetActive(false);
            GameManager.Instance.OnGameOver += GameManager_OnGameOver;
        }

        private void GameManager_OnGameOver(object sender, EventArgs e)
        {
            playerWinText.gameObject.SetActive(true);
            string winner = ScoreManager.Instance.IsPlayerOneMaxScore() ? "PLAYER ONE" : "PLAYER TWO";
            playerWinText.text = winner + " WIN";
        }
    }
}