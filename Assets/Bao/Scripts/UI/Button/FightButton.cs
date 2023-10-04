using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class FightButton : BaseButton
{
    private readonly float DEFAULT_TIME_LOAD_SCENE = 1f;
    [SerializeField] private Transform battleVSPanel;
    [SerializeField] private Animator battleVSPanelAnimator;

    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.battleVSPanel = GameObject.Find("Canvas").transform.Find("Battle VS Panel");
        this.battleVSPanelAnimator = battleVSPanel.GetComponent<Animator>();
    }

    protected override void OnClick()
    {
        base.OnClick();
        this.battleVSPanel.gameObject.SetActive(true);
        this.battleVSPanelAnimator.SetTrigger("Close");
        StartCoroutine(this.LoadScene());
    }

    private IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(DEFAULT_TIME_LOAD_SCENE);
        int indexSceneNext = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(indexSceneNext);
    }
}
