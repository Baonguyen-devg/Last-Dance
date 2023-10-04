using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public partial class UIController : AutoMonoBehaviour
{
    [Header("[ Panels ]"), Space(6)]
    [SerializeField] private GameObject gameLosePanel;
    [SerializeField] private GameObject pauseGamePanel;
    [SerializeField] private GameObject mainGamePanel;
    [SerializeField] private GameObject vsBattlePanel;

    [SerializeField] private Animator vsBattlePanelAnimator;
    [SerializeField] private float timeAppearMainPanel = 1f;
    [SerializeField] private float timeDisApearVSBattlePanel = 2f;

    public float TimeAppearMainPanel => this.timeAppearMainPanel;

    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        this.gameLosePanel = transform.Find("End Game Panel").gameObject;
        this.pauseGamePanel = transform.Find("Pause Game Panel").gameObject;
        this.mainGamePanel = transform.Find("Main Game Panel").gameObject;
        this.vsBattlePanel = transform.Find("Battle VS Panel").gameObject;
        this.vsBattlePanelAnimator = this.vsBattlePanel.GetComponent<Animator>();
    }

    private void Start()
    {
        this.vsBattlePanel.SetActive(true);
        this.vsBattlePanelAnimator.SetTrigger("Open");

        StartCoroutine(this.ActiveMainGamePanel());
        StartCoroutine(this.DisActiveVSBattlePanel());
    }

    private IEnumerator ActiveMainGamePanel()
    {
        yield return new WaitForSeconds(this.timeAppearMainPanel);
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

    public virtual void OnGameLosePanel() => this.gameLosePanel.SetActive(true);

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
