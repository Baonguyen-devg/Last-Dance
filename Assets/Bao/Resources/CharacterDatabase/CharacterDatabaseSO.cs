using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterDatabase", menuName = "ScriptableObjects/CharacterDatabase")]
public class CharacterDatabaseSO : ScriptableObject 
{
#if UNITY_EDITOR
    [TextArea(2, 10), Space(6)]
    [SerializeField] protected string DeveloperDescription = "";
#endif

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
