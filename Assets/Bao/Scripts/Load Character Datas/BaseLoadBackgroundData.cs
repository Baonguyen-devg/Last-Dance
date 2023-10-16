using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseLoadBackgroundData : AutoMonoBehaviour
{
    [TextArea, Space(6)]
    [SerializeField] protected string DeveloperDescription = "";

    #region Variables
    [Header("[ Background database scriptable object ]"), Space(6)]
    protected readonly string PATH = "BackgroundDatabase/BackgroundDatabase";
    [SerializeField] protected BackgroundDatabaseSO backgroundDatabaseSO;

    [Header("[ Validation ]"), Space(6)]
    [SerializeField] protected bool haveNullValue = false;
    [SerializeField] protected bool logWhenNull = true;
    #endregion

    #region Load component methods
    [ContextMenu("Load Component")]
    protected override void LoadComponent() =>
         this.backgroundDatabaseSO = Resources.Load<BackgroundDatabaseSO>(PATH);
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
        this.backgroundDatabaseSO.Equals(null);
    #endregion
}
