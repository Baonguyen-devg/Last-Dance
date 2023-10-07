using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CountdownUI : AutoMonoBehaviour
{
    [Header("[ Component ]"), Space(6)]
    [SerializeField] private List<Transform> prefabs;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private UIController uiController;

    [SerializeField] private int count = 0;
    [SerializeField] private float rateCountDown = 0;
    [SerializeField] private float timeCountDown = 0;

    [ContextMenu("Load Component")] 
    protected override void LoadComponent()
    {
        base.LoadComponent();
        if (this.prefabs.Count != 0) this.prefabs.Clear();
        prefabs.AddRange(transform.Cast<Transform>());

        this.uiController = GameObject.Find("Canvas").GetComponent<UIController>();
        this.gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Start() => this.LoadRateCountDown();

    private void LoadRateCountDown()
    {
        float time = this.gameManager.DEFAULT_COUNTDOWN_START;
        this.rateCountDown = (float) time / this.prefabs.Count;
    }

    private void Update()
    {
        if (this.count >= this.prefabs.Count) return;
        this.timeCountDown = this.timeCountDown - Time.deltaTime;
        if (this.timeCountDown > 0) return;

        this.timeCountDown = this.rateCountDown;
        this.NextPrefab();
    }

    private void NextPrefab()
    {
        this.prefabs[count].gameObject.SetActive(true);
        StartCoroutine(this.DisActivePrefab(this.prefabs[count]));
        this.count = this.count + 1;
    }

    private IEnumerator DisActivePrefab(Transform prefab)
    {
        yield return new WaitForSeconds(this.rateCountDown);
        prefab.gameObject.SetActive(false);
    }
}
