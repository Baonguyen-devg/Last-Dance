using UnityEngine;

[System.Serializable]
public class Background
{
    [SerializeField] private string nameBackground;
    [SerializeField] private Transform backgroundObject;

    public string NameBackground => this.nameBackground;
    public Transform BackgroundObject => this.backgroundObject;
}
