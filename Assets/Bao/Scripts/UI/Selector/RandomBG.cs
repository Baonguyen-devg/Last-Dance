using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBG : BaseLoadBackgroundData
{
    private readonly string nameSetDataBackground = "Background";
    private void Start() => this.RandomBackgound();

    [ContextMenu("Random Background")]
    private void RandomBackgound()
    {
        string nameBackground = this.backgroundDatabaseSO.GetRandomBackground();
        Debug.Log("Background random's name is: " + nameBackground, gameObject);
        PlayerPrefs.SetString(nameSetDataBackground, nameBackground);
    }
}
