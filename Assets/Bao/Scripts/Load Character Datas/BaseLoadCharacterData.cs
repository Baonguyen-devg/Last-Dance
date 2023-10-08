using UnityEngine;

public class BaseLoadCharacterData : AutoMonoBehaviour
{
    [TextArea(2, 10), Space(6)]
    [SerializeField] protected string DeveloperDescription = "";

    [Header("[ Character database scriptable object ]"), Space(6)]
    protected readonly string PATH = "CharacterDatabase/CharacterDatabase";
    [SerializeField] protected CharacterDatabaseSO characterDatabaseSO;

    [ContextMenu("Load Component")]
    protected override void LoadComponent() =>
         this.characterDatabaseSO = Resources.Load<CharacterDatabaseSO>(PATH);

    [Header("[ Validation ]"), Space(6)]
    [SerializeField] protected bool haveNullValue = false;
    [SerializeField] protected bool logWhenNull = true;

    protected virtual void Start()
    {
        this.haveNullValue = this.CheckNullAllSerializeFields();
        if (this.haveNullValue)
        {
            if (this.logWhenNull) Debug.LogError($"Disactive because [{name}] having null values", this);
            gameObject.SetActive(false);
        }
    }

    protected virtual bool CheckNullAllSerializeFields() =>
        this.characterDatabaseSO.Equals(null);
}
