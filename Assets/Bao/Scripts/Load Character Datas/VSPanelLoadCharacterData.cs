using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VSPanelLoadCharacterData : BaseLoadCharacterData
{
    [SerializeField] private Transform battleVSPlayer_1;
    [SerializeField] private Transform battleVSPlayer_2;

    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.battleVSPlayer_1 = transform.Find("Side Left").Find("Player");
        this.battleVSPlayer_2 = transform.Find("Side Right").Find("Player");
    }

    protected override void Start()
    {
        base.Start();
        this.LoadData(this.battleVSPlayer_1, "Player_One");
        this.LoadData(this.battleVSPlayer_2, "Player_Two");
    }

    private void LoadData(
        Transform battleVSPlayer,
        string nameKey
    ) {
        string nameCharacter = PlayerPrefs.GetString(nameKey);
        Character character = this.characterDatabaseSO.GetCharacterByName(nameCharacter);
        this.SetData(battleVSPlayer, character);
    }

    private void SetData(
        Transform battleVsPlayer,
        Character character
    ) {
        battleVsPlayer.Find("Model").GetComponent<Image>().sprite = character.Sprite;
        battleVsPlayer.Find("Name").GetComponent<Text>().text = character.NameCharacter;
    }
}
