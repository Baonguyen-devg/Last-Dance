using UnityEngine;

public class BaseLoadCharacterData : AutoMonoBehaviour
{
    [Header("[ Character database scriptable object ]"), Space(6)]
    protected readonly string PATH = "CharacterDatabase/CharacterDatabase";
    [SerializeField] protected CharacterDatabaseSO characterDatabaseSO;

    [ContextMenu("Load Component")]
    protected override void LoadComponent() =>
         this.characterDatabaseSO = Resources.Load<CharacterDatabaseSO>(PATH);
}
