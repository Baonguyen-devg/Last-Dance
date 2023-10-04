using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoadCharacterData : BaseLoadCharacterData
{
    [Header("[ Player 1 and Player 2 sprite ]"), Space(6)]
    [SerializeField] private SpriteRenderer spritePlayer_1;
    [SerializeField] private SpriteRenderer spritePlayer_2;

    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpritePlayer("Player_One", this.spritePlayer_1);
        this.LoadSpritePlayer("Player_Two", this.spritePlayer_2);
    }

    private void LoadSpritePlayer(
        string name, 
        SpriteRenderer spriteRenderer
    ) {
        Transform headPlayer = GameObject.Find(name).transform.Find(name + "_Head");
        spriteRenderer = headPlayer.Find("Model").GetComponent<SpriteRenderer>();
        this.LoadData(spriteRenderer, name);
    }

    private void LoadData(
        SpriteRenderer spritePlayer,
        string nameKey
    ) {
        string nameCharacter = PlayerPrefs.GetString(nameKey);
        Character character = this.characterDatabaseSO.GetCharacterByName(nameCharacter);
        this.SetData(spritePlayer, character);
    }

    private void SetData(
        SpriteRenderer battleVsPlayer,
        Character character
    ) => battleVsPlayer.sprite = character.Sprite;
}
