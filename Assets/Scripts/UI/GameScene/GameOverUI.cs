using System;
using TMPro;
using UnityEngine;
using System.Collections;

namespace DefaultNamespace.UI.GameScene
{
    public class GameOverUI : AutoMonoBehaviour
    {
        private readonly float TIME_APPEAR_UI_END_GAME = 1f;
        private readonly float TIME_EMPTY = 0.5f;
        #if UNITY_EDITOR
        [TextArea(2, 10), SerializeField] private string DeveloperDescriber = "";
        #endif

        #region Variables
        [Header("[ Texts Mesh Pro UGUI ]"), Space(6)]
        [SerializeField] private TextMeshProUGUI playerWinText;
        [SerializeField] private Animator animator;
        #endregion

        #region Load component methods
        [ContextMenu("Load Component")]
        protected override void LoadComponent()
        {
            base.LoadComponent();
            this.playerWinText = transform.Find("Win Player Name Text").GetComponent<TextMeshProUGUI>();
            this.animator = gameObject.GetComponent<Animator>();
        }
        #endregion

        #region Main methods
        private void OnEnable() => this.OnGameOver();

        private void OnGameOver()
        {
            this.animator.SetTrigger("AppearKOText");
            StartCoroutine(this.TimeEmpty());
        }
        
        private IEnumerator TimeEmpty()
        {
            yield return new WaitForSeconds(TIME_EMPTY);
            StartCoroutine(this.AppearUIEndGame());
        }

        private IEnumerator AppearUIEndGame()
        {
            yield return new WaitForSeconds (TIME_APPEAR_UI_END_GAME);

            this.animator.SetTrigger("AppearUIEndGame");
            string winner = ScoreManager.Instance.IsPlayerOneMaxScore() ? "PLAYER 1" : "PLAYER 2";
            playerWinText.text = winner;
        }
        #endregion
    }
}