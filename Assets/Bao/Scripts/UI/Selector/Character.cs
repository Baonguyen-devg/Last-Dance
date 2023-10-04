using UnityEngine;

[System.Serializable]
public class Character 
{
    [SerializeField] private string nameCharacter;
    [SerializeField] private Sprite sprite;

    public string NameCharacter => this.nameCharacter;
    public Sprite Sprite => this.sprite;
}
