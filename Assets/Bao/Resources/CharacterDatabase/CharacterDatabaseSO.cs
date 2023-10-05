using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterDatabase", menuName = "ScriptableObjects/CharacterDatabase")]
public class CharacterDatabaseSO : ScriptableObject 
{
    [Header("[ Character list ]"), Space(6)]
    [SerializeField] private Character[] characters;
    public Character[] Characters => this.characters;

    public virtual Character GetCharacterByName(
        string name
    ) {
        foreach (Character character in this.Characters)
            if (character.NameCharacter.Equals(name)) return character;
        return null;
    }
}
