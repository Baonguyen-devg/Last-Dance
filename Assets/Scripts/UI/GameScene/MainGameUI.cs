using TMPro;
using UnityEngine;

namespace DefaultNamespace.UI.GameScene
{
    public class MainGameUI : AutoMonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI playerOneScoreText;
        [SerializeField] private TextMeshProUGUI playerOneScoreTwo;

        [SerializeField] private TextMeshProUGUI ResultPlayer_1;
        [SerializeField] private TextMeshProUGUI ResultPlayer_2;

        [ContextMenu("Load Component")]
        protected override void LoadComponent()
        {
            base.LoadComponent();
            this.playerOneScoreText = transform.Find("Score Player One Text").GetComponent<TextMeshProUGUI>();
            this.playerOneScoreTwo = transform.Find("Score Player Two Text").GetComponent<TextMeshProUGUI>();

            this.ResultPlayer_1 ??= transform.Find("Result Player 1").GetComponentInChildren<TextMeshProUGUI>();
            this.ResultPlayer_2 ??= transform.Find("Result Player 2").GetComponentInChildren<TextMeshProUGUI>();
        }

        private void Start()
        {
            ScoreManager.Instance.OnScorePlayerOneChanged += ScoreManager_OnScorePlayerOneChanged;
            ScoreManager.Instance.OneScorePlayerTwoChanged += ScoreManager_OnScorePlayerTwoChanged;

            playerOneScoreText.text = ScoreManager.Instance.ScorePlayerOne.ToString();
            playerOneScoreTwo.text = ScoreManager.Instance.ScorePlayerTwo.ToString();
        }

        public virtual void AppearResultPlayers(bool isPlayerOneWin)
        {
            this.ResultPlayer_1.text = "Lose";
            this.ResultPlayer_2.text = "Win";

            if (isPlayerOneWin)
            {
                this.ResultPlayer_1.text = "Win";
                this.ResultPlayer_2.text = "Lose";
            }

            this.ResultPlayer_1.transform.parent.gameObject.SetActive(true);
            this.ResultPlayer_2.transform.parent.gameObject.SetActive(true);
        }

        private void ScoreManager_OnScorePlayerOneChanged(int i) => playerOneScoreText.text = i.ToString();
        private void ScoreManager_OnScorePlayerTwoChanged(int i) => playerOneScoreTwo.text = i.ToString();
    }
}