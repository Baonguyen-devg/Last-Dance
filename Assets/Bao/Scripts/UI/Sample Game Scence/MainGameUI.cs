using TMPro;
using UnityEngine;

namespace DefaultNamespace.UI.GameScene
{
    public class MainGameUI : AutoMonoBehaviour
    {
        private readonly string WIN_TEXT = "Win";
        private readonly string LOSE_TEXT = "Lose";

        #region Varibles
        [Header("[ Text Mesh Pro UGUI ]"), Space(6)]
        [SerializeField] private TextMeshProUGUI playerOneScoreText;
        [SerializeField] private TextMeshProUGUI playerOneScoreTwo;

        [SerializeField] private TextMeshProUGUI ResultPlayer_1;
        [SerializeField] private TextMeshProUGUI ResultPlayer_2;
        #endregion

        #region Load component methods
        [ContextMenu("Load Component")]
        protected override void LoadComponent()
        {
            base.LoadComponent();
            this.playerOneScoreText = transform.Find("Score Player One Text").GetComponent<TextMeshProUGUI>();
            this.playerOneScoreTwo = transform.Find("Score Player Two Text").GetComponent<TextMeshProUGUI>();

            this.ResultPlayer_1 ??= transform.Find("Result Player 1").GetComponentInChildren<TextMeshProUGUI>();
            this.ResultPlayer_2 ??= transform.Find("Result Player 2").GetComponentInChildren<TextMeshProUGUI>();
        }
        #endregion

        #region Main methods
        private void Start()
        {
            ScoreManager.Instance.OnScorePlayerOneChanged += ScoreManager_OnScorePlayerOneChanged;
            ScoreManager.Instance.OneScorePlayerTwoChanged += ScoreManager_OnScorePlayerTwoChanged;

            playerOneScoreText.text = ScoreManager.Instance.ScorePlayerOne.ToString();
            playerOneScoreTwo.text = ScoreManager.Instance.ScorePlayerTwo.ToString();
        }

        public virtual void AppearResultPlayers(bool isPlayerOneWin)
        {
            this.ResultPlayer_1.text = LOSE_TEXT;
            this.ResultPlayer_2.text = WIN_TEXT;

            if (isPlayerOneWin)
            {
                this.ResultPlayer_1.text = WIN_TEXT;
                this.ResultPlayer_2.text = LOSE_TEXT;
            }

            this.ResultPlayer_1.transform.parent.gameObject.SetActive(true);
            this.ResultPlayer_2.transform.parent.gameObject.SetActive(true);
        }

        private void ScoreManager_OnScorePlayerOneChanged(int i) => playerOneScoreText.text = i.ToString();
        private void ScoreManager_OnScorePlayerTwoChanged(int i) => playerOneScoreTwo.text = i.ToString();
        #endregion
    }
}