using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VSPanelLoadCharacterData : BaseLoadCharacterData
{
    private readonly string NAME_PLAYER_ONE = "Player_One";
    private readonly string NAME_PLAYER_TWO = "Player_Two";

    #region Variables
    [Header("[ Components ]"), Space(6)]
    [SerializeField] private Transform battleVSPlayer_1;
    [SerializeField] private Transform battleVSPlayer_2;
    #endregion

    #region Load component methods
    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.battleVSPlayer_1 = transform.Find("Side Left").Find("Player");
        this.battleVSPlayer_2 = transform.Find("Side Right").Find("Player");
    }
    #endregion

    #region Main methods
    protected override void Start()
    {
        base.Start();
        this.LoadData(this.battleVSPlayer_1, NAME_PLAYER_ONE);
        this.LoadData(this.battleVSPlayer_2, NAME_PLAYER_TWO);
    }

    public virtual void LoadDataByName(
        string nameCharacter
    ){
        if (nameCharacter.Equals(NAME_PLAYER_ONE))
            this.LoadData(this.battleVSPlayer_1, NAME_PLAYER_ONE);
        else
            this.LoadData(this.battleVSPlayer_2, NAME_PLAYER_TWO);
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
        battleVsPlayer.Find("Name").GetComponent<TextMeshProUGUI>().text = character.NameCharacter;
    }
    #endregion
}
