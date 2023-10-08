using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseLoadBackgroundData : AutoMonoBehaviour
{
    [TextArea(2, 10), Space(6)]
    [SerializeField] protected string DeveloperDescription = "";

    [Header("[ Background database scriptable object ]"), Space(6)]
    protected readonly string PATH = "BackgroundDatabase/BackgroundDatabase";
    [SerializeField] protected BackgroundDatabaseSO backgroundDatabaseSO;

    [Header("[ Validation ]"), Space(6)]
    [SerializeField] protected bool haveNullValue = false;
    [SerializeField] protected bool logWhenNull = true;
  
    [ContextMenu("Load Component")]
    protected override void LoadComponent() =>
         this.backgroundDatabaseSO = Resources.Load<BackgroundDatabaseSO>(PATH);

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
        this.backgroundDatabaseSO.Equals(null);
}
