using UnityEngine;

public class GameLoadBackgroundData : BaseLoadBackgroundData
{
    #region Main methods
    protected override void Start()
    {
        base.Start();
        this.LoadData(PlayerPrefs.GetString("Background"));
    }

    private void LoadData(
        string nameKey
    ) {
        Background background = this.backgroundDatabaseSO.GetBackgroundByName(nameKey);
        Transform bg = Instantiate(background.BackgroundObject);
        this.SetStatusBackground(bg);
    }

    private void SetStatusBackground(
        Transform background
    ) {
        background.gameObject.SetActive(true);
        background.SetParent(transform);
    }
    #endregion
}
