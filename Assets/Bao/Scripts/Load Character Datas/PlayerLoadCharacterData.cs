using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class PlayerLoadCharacterData : BaseLoadCharacterData
{
    private readonly string DEFAULT_HEAD_PLAYER_NAME = "_Head";

    #region Variables
    [Space(12), Header("[ Player 1 and Player 2 sprite ]"), Space(6)]
    [SerializeField] private SpriteRenderer spritePlayer_1;
    [SerializeField] private SpriteRenderer spritePlayer_2;
    #endregion

    #region Load component methods
    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpritePlayer("Player_One", this.spritePlayer_1);
        this.LoadSpritePlayer("Player_Two", this.spritePlayer_2);
    }

    public Sprite LoadSpritePlayer(
        string name, 
        SpriteRenderer spriteRenderer
    ) {
        Transform headPlayer = GameObject.Find(name).transform.Find(this.StringBuiderText(name));
        spriteRenderer = headPlayer.Find("Model").GetComponent<SpriteRenderer>();
        return this.LoadData(spriteRenderer, name);
    }

    private string StringBuiderText(
        string name
    ) => new StringBuilder().Append(name).Append(DEFAULT_HEAD_PLAYER_NAME).ToString();

    private Sprite LoadData(
        SpriteRenderer spritePlayer,
        string nameKey
    ) {
        string nameCharacter = PlayerPrefs.GetString(nameKey);
        Character character = this.characterDatabaseSO.GetCharacterByName(nameCharacter);
        spritePlayer.transform.localScale = character.RateScale;
        return this.SetData(spritePlayer, character);
    }

    private Sprite SetData(
        SpriteRenderer battleVsPlayer,
        Character character
    ) {
        battleVsPlayer.sprite = character.Sprite;
        return character.Sprite;
    }
    #endregion
}
