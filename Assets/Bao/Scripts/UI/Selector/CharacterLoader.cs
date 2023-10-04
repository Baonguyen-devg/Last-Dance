using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterLoader : AutoMonoBehaviour 
{
    private const string PATH = "CharacterDatabase/CharacterDatabase";

    [Header("[ Load characters database]"), Space(6)]
    [SerializeField] private CharacterDatabaseSO characterDatabaseSO;
    [SerializeField] private List<Character> charactersData;

    [Header("[ Create charactersData]"), Space(6)]
    [SerializeField] private Transform baseCharacter;
    [SerializeField] private Transform holder;
    [SerializeField] private List<Transform> characters;

    public List<Transform> Characters => this.characters;
    public List<Character> CharactersData => this.charactersData;
    
    [ContextMenu("Load Component")]
    protected override void LoadComponent() 
    {
        this.characterDatabaseSO = Resources.Load<CharacterDatabaseSO>(PATH);
        this.charactersData = new List<Character>(this.characterDatabaseSO.Characters);

        this.holder = transform.Find("Holder");
        this.baseCharacter = transform.Find("Base Character");
    }

    protected override void Awake() 
    {
        base.Awake();
        this.CreateCharacters();
    }

    private void CreateCharacters() 
    {
        foreach (Character character in this.charactersData) 
        {
            GameObject newCharacter = Instantiate(this.baseCharacter.gameObject);
            this.characters.Add(newCharacter.transform);

            this.SetStatusCharacter(newCharacter);
            this.SetDataCharacter(newCharacter, character);
        }
    }

    private void SetDataCharacter(
        GameObject newCharacter,
        Character character
    ) {
        newCharacter.name = character.NameCharacter;
        newCharacter.transform.Find("Model").GetComponent<Image>().sprite = character.Sprite;
    }

    private void SetStatusCharacter(
        GameObject character
    ) {
        character.transform.SetParent(this.holder);
        character.transform.localPosition = Vector3.zero;
        character.transform.localScale = new Vector3(1, 1, 1);
        character.SetActive(true);
    }
}
