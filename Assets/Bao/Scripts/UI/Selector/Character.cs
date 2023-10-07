using UnityEngine;

[System.Serializable]
public class Character 
{
    [SerializeField] private string nameCharacter;
    [SerializeField] private Sprite sprite;
    [SerializeField] private Vector3 rateScale;

    public string NameCharacter => this.nameCharacter;
    public Sprite Sprite => this.sprite;
    public Vector3 RateScale => this.rateScale;
}
