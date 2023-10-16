using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneUI : AutoMonoBehaviour
{
    #region Variables
    [Header("[ Component ]"), Space(6)]
    [SerializeField] private List<GameObject> options;
    [SerializeField] private int count = 0;

    [SerializeField] private GameObject CreditPanel;
  /*  [SerializeField] private ButtonUI nextButton;
    [SerializeField] private ButtonUI backButton;*/
    #endregion

    #region Load component methods
    [ContextMenu("Load component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadOptionPrefabs();
    }

    private void LoadOptionPrefabs()
    {
        this.options.Clear();
        Transform optionPrefabs = transform.Find("Options");
        foreach (Transform prefab in optionPrefabs)
            this.options.Add(prefab.gameObject);
    }
    #endregion

    #region Main methods
    public virtual void Update()
    {
        if (this.CreditPanel.activeSelf) return;
        if (Input.GetKeyDown(KeyCode.Return)) this.ChoseOption();
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) this.BackOption();
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) this.NextOption();
    }

    private void ChoseOption()
    {
        switch (this.options[count].name)
        {
            case "Play Game":
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;

            case "Credit":
                this.CreditPanel.SetActive(true);
                break;

            case "Quit":
                Application.Quit();
                break;
        }
    }

    public virtual void BackOption()
    {
        this.options[count].SetActive(false);
        this.count = (this.count - 1 + this.options.Count) % this.options.Count;
        this.options[count].SetActive(true);
    }

    public virtual void NextOption()
    {
        this.options[count].SetActive(false);
        this.count = (this.count + 1) % this.options.Count;
        this.options[count].SetActive(true);
    }
    #endregion
}
