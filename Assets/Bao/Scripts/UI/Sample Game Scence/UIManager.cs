using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using DefaultNamespace.UI.GameScene;

public partial class UIManager : AutoMonoBehaviour
{
    private const float DEFAULT_TIME_APPEAR_MAIN = 1f;
    private readonly string NAME_PLAYER_PREFS_DATA = "TurnOnBattleVS";

    private static UIManager instance;
    public static UIManager Instance => instance;

    #region Variables
    [Header("[ Panels ]"), Space(6)]
    [SerializeField] private GameObject endGamePanel;
    [SerializeField] private GameObject pauseGamePanel;
    [SerializeField] private GameObject mainGamePanel;
    [SerializeField] private GameObject vsBattlePanel;

    [SerializeField] private MainGameUI mainGameUI;
    [SerializeField] private Animator vsBattlePanelAnimator;
    [SerializeField] private float timeAppearMainPanel = DEFAULT_TIME_APPEAR_MAIN;
    [SerializeField] private float timeDisApearVSBattlePanel = 2f;
    #endregion

    public float TimeAppearMainPanel => this.timeAppearMainPanel;
    public MainGameUI MainGameUI => this.mainGameUI;

    #region Load component methods
    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        this.endGamePanel = transform.Find("End Game Panel").gameObject;
        this.pauseGamePanel = transform.Find("Pause Game Panel").gameObject;
        this.mainGamePanel = transform.Find("Main Game Panel").gameObject;
        this.vsBattlePanel = transform.Find("Battle VS Panel").gameObject;

        this.vsBattlePanelAnimator = this.vsBattlePanel.GetComponent<Animator>();
        this.mainGameUI = GetComponentInChildren<MainGameUI>();
    }
    #endregion

    #region Main methods
    protected override void Awake()
    {
        base.Awake();
        UIManager.instance = this;
        if (PlayerPrefs.GetString(NAME_PLAYER_PREFS_DATA).Equals("Off"))
        {
            this.timeAppearMainPanel = 0;
            StartCoroutine(this.ActiveMainGamePanel(0));
            return;
        }

        StartCoroutine(this.ActiveMainGamePanel(this.timeAppearMainPanel));
        PlayerPrefs.SetString(NAME_PLAYER_PREFS_DATA, "Off");

        this.vsBattlePanel.SetActive(true);
        this.vsBattlePanelAnimator.SetTrigger("Open");

        StartCoroutine(this.DisActiveVSBattlePanel());
    }

    private void Start()
    {
        if (GameManager.Instance == null) return;
        GameManager.Instance.OnGamePaused += this.OnPauseGamePanel;
        GameManager.Instance.OnGameUnpaused += this.OffPauseGamePanel;
        GameManager.Instance.OnGameOver += this.OnGameLosePanel;

        GameManager.Instance?.SetStateCountDownToStart(); //de tam thoi o day
    }

    private void OnDestroy()
    {
        if (GameManager.Instance == null) return;
        GameManager.Instance.OnGamePaused -= this.OnPauseGamePanel;
        GameManager.Instance.OnGameUnpaused -= this.OffPauseGamePanel;
        GameManager.Instance.OnGameOver -= this.OnGameLosePanel;
    }

    private IEnumerator ActiveMainGamePanel(float timeWaiting)
    {
        yield return new WaitForSeconds(timeWaiting);
        this.mainGamePanel.gameObject.SetActive(true);
    }
    
    private IEnumerator DisActiveVSBattlePanel()
    {
        yield return new WaitForSeconds(this.timeDisApearVSBattlePanel);
        this.vsBattlePanel.SetActive(false);
    }

    public virtual void OnGameLosePanel(object sender, EventArgs e)
    {
        if (this.endGamePanel == null) Debug.Log("HERE");
        else this.endGamePanel.SetActive(true);
    }

    public virtual void OnPauseGamePanel(object sender, EventArgs e) => 
        this.pauseGamePanel.SetActive(true);

    public virtual void OffPauseGamePanel(object sender, EventArgs e) =>
        this.pauseGamePanel.SetActive(false);
    #endregion
}
