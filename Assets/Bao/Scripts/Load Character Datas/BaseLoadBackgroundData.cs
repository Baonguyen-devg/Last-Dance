using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseLoadBackgroundData : AutoMonoBehaviour
{
    [Header("[ Background database scriptable object ]"), Space(6)]
    protected readonly string PATH = "BackgroundDatabase/BackgroundDatabase";
    [SerializeField] protected BackgroundDatabaseSO backgroundDatabaseSO;

    [ContextMenu("Load Component")]
    protected override void LoadComponent() =>
         this.backgroundDatabaseSO = Resources.Load<BackgroundDatabaseSO>(PATH);
}
