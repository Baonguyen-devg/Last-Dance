using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomBackground : BaseLoadBackgroundData
{
    private void Start() => this.LoadData(PlayerPrefs.GetString("Background"));

    private void LoadData(
        string nameKey
    ) {
        Background background = this.backgroundDatabaseSO.GetBackgroundByName(nameKey);
        Transform bg = Instantiate(background.BackgroundObject);
        bg.gameObject.SetActive(true);
        bg.SetParent(transform);
    }
}
