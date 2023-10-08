using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public partial class UIController : AutoMonoBehaviour
{
    private const float DEFAULT_TIME_APPEAR_MAIN = 1f;
    private static UIController instance;
    public static UIController Instance => instance;

    [Header("[ Panels ]"), Space(6)]
    [SerializeField] private GameObject endGamePanel;
    [SerializeField] private GameObject pauseGamePanel;
    [SerializeField] private GameObject mainGamePanel;
    [SerializeField] private GameObject vsBattlePanel;

    [SerializeField] private Animator vsBattlePanelAnimator;
    [SerializeField] private float timeAppearMainPanel = DEFAULT_TIME_APPEAR_MAIN;
    [SerializeField] private float timeDisApearVSBattlePanel = 2f;

    public float TimeAppearMainPanel => this.timeAppearMainPanel;

    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        this.endGamePanel = transform.Find("End Game Panel").gameObject;
        this.pauseGamePanel = transform.Find("Pause Game Panel").gameObject;
        this.mainGamePanel = transform.Find("Main Game Panel").gameObject;
        this.vsBattlePanel = transform.Find("Battle VS Panel").gameObject;
        this.vsBattlePanelAnimator = this.vsBattlePanel.GetComponent<Animator>();
    }

    protected override void Awake()
    {
        base.Awake();
        UIController.instance = this;
        if (PlayerPrefs.GetString("TurnOnBattleVS").Equals("Off"))
        {
            this.timeAppearMainPanel = 0;
            StartCoroutine(this.ActiveMainGamePanel(0));
            return;
        }

        StartCoroutine(this.ActiveMainGamePanel(this.timeAppearMainPanel));
        PlayerPrefs.SetString("TurnOnBattleVS", "Off");

        this.vsBattlePanel.SetActive(true);
        this.vsBattlePanelAnimator.SetTrigger("Open");

        StartCoroutine(this.DisActiveVSBattlePanel());
    }

    private void Start() => GameManager.Instance.OnGameOver += this.OnEndGame;

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            this.OnPauseGamePanel();
        }
    }

    private void OnEndGame(System.Object sender, System.EventArgs e) =>
        this.endGamePanel.SetActive(true);

    public virtual void OnGameLosePanel() => this.endGamePanel.SetActive(true);

    public virtual void OnPauseGamePanel() => this.pauseGamePanel.SetActive(true);

    public virtual void ContinueGame() => Time.timeScale = 1;

    public virtual void BackMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    public virtual void PlayAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
