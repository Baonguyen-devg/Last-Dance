using System;
using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace DefaultNamespace.UI.GameScene
{
    public class GameOverUI : AutoMonoBehaviour
    {
        private readonly float TIME_APPEAR_UI_END_GAME = 1f;
        private readonly float TIME_EMPTY = 1f;

        private readonly string APPEAR_KO_TRIGGER = "AppearKOText";
        private readonly string APPEAR_UI_TRIGGER = "AppearUIEndGame";
        private readonly string NAME_PLAYER_1 = "PLAYER 1";
        private readonly string NAME_PLAYER_2 = "PLAYER_2";

        #if UNITY_EDITOR
        [TextArea(2, 10), SerializeField] private string DeveloperDescriber = "";
        #endif

        #region Variables
        [Header("[ Texts Mesh Pro UGUI ]"), Space(6)]
        [SerializeField] private Image playerWinImage;
        [SerializeField] private PlayerLoadCharacterData playerLoadCharacterData;
        [SerializeField] private TextMeshProUGUI playerWinText;

        [SerializeField] private Animator animator;
        [SerializeField] private Button playAgainButton;
        #endregion

        #region Load component methods
        [ContextMenu("Load Component")]
        protected override void LoadComponent()
        {
            base.LoadComponent();
            this.playerWinText = transform.Find("Win Player Name Text").GetComponent<TextMeshProUGUI>();
            this.animator = gameObject.GetComponent<Animator>();

            this.playerLoadCharacterData = GameObject.Find("Load Data").GetComponent<PlayerLoadCharacterData>();
            this.playerWinImage = transform.Find("Player Win Image").GetComponent<Image>();
            this.playAgainButton = transform.Find("Play Again Button").GetComponent<Button>();
        }
        #endregion

        #region Main methods
        private void OnEnable() => this.OnGameOver();

        private void OnGameOver()
        {
            UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(this.playAgainButton.gameObject);
            this.animator.SetTrigger(APPEAR_KO_TRIGGER);
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

            this.animator.SetTrigger(APPEAR_UI_TRIGGER);
            string winner = ScoreManager.Instance.IsPlayerOneMaxScore() ? NAME_PLAYER_1 : NAME_PLAYER_2;
            playerWinText.text = winner;

            if (winner.Equals(NAME_PLAYER_1)) 
                this.playerWinImage.sprite = this.playerLoadCharacterData.LoadSpritePlayer("Player_One", null);
            else
                this.playerWinImage.sprite = this.playerLoadCharacterData.LoadSpritePlayer("Player_Two", null);
        }
        #endregion
    }
}