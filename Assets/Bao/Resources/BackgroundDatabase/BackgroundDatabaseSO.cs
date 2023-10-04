using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BackgroundDatabase", menuName = "ScriptableObjects/BackgroundDatabase")]
public class BackgroundDatabaseSO : ScriptableObject
{   
    [Header("[ Background list ]"), Space(6)]
    [SerializeField] private Background[] backgrounds;
    public Background[] Backgrounds => this.backgrounds;

    public virtual Background GetBackgroundByName(
        string name
    ) {
        foreach (Background background in this.backgrounds)
            if (background.NameBackground.Equals(name)) return background;
        return null;
    }

    public virtual string GetRandomBackground() =>
        this.backgrounds[Random.Range(0, this.backgrounds.Length)].NameBackground;
}
