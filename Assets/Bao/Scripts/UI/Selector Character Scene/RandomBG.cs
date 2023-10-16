using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBG : BaseLoadBackgroundData
{
    private readonly string nameSetDataBackground = "Background";
    private readonly string NAME_PLAYER_PREFS_DATA = "TurnOnBattleVS";

    protected override void Start()
    {
        base.Start();
        this.RandomBackgound();
    }

    [ContextMenu("Random Background")]
    private void RandomBackgound()
    {
        //Divid into a class about SetUpUI BattleVS
        PlayerPrefs.SetString(NAME_PLAYER_PREFS_DATA, "On");

        string nameBackground = this.backgroundDatabaseSO.GetRandomBackground();
        NewLog.DebugLog("Background random's name is: " + nameBackground, gameObject);
        PlayerPrefs.SetString(nameSetDataBackground, nameBackground);
    }
}
