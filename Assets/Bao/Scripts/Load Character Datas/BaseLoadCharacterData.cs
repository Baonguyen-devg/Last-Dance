using UnityEngine;

public class BaseLoadCharacterData : AutoMonoBehaviour
{
    [TextArea, Space(6)]
    [SerializeField] protected string DeveloperDescription = "";

    #region Variables
    [Header("[ Character database scriptable object ]"), Space(6)]
    protected readonly string PATH = "CharacterDatabase/CharacterDatabase";
    [SerializeField] protected CharacterDatabaseSO characterDatabaseSO;

    [Header("[ Validation ]"), Space(6)]
    [SerializeField] protected bool haveNullValue = false;
    [SerializeField] protected bool logWhenNull = true;
    #endregion

    #region Load component methods
    [ContextMenu("Load Component")]
    protected override void LoadComponent() =>
         this.characterDatabaseSO = Resources.Load<CharacterDatabaseSO>(PATH);
    #endregion

    #region Main methods
    protected virtual void Start()
    {
        this.haveNullValue = this.CheckNullAllSerializeFields();
        if (this.haveNullValue)
        {
            if (this.logWhenNull) NewLog.DebugLog($"Disactive because [{name}] having null values", this);
            gameObject.SetActive(false);
        }
    }

    protected virtual bool CheckNullAllSerializeFields() =>
        this.characterDatabaseSO.Equals(null);
    #endregion
}
