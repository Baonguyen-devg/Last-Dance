using TMPro;
using UnityEngine;

namespace DefaultNamespace.UI.GameScene
{
    public class MainGameUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI playerOneScoreText;
        [SerializeField] private TextMeshProUGUI playerOneScoreTwo;

        private void Start()
        {
            ScoreManager.Instance.OnScorePlayerOneChanged += ScoreManager_OnScorePlayerOneChanged;
            ScoreManager.Instance.OneScorePlayerTwoChanged += ScoreManager_OnScorePlayerTwoChanged;

            playerOneScoreText.text = ScoreManager.Instance.ScorePlayerOne.ToString();
            playerOneScoreTwo.text = ScoreManager.Instance.ScorePlayerTwo.ToString();
        }

        private void ScoreManager_OnScorePlayerOneChanged(int i) => playerOneScoreText.text = i.ToString();
        private void ScoreManager_OnScorePlayerTwoChanged(int i) => playerOneScoreTwo.text = i.ToString();
    }
}