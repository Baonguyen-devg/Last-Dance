using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackOptionButton : BaseButton
{
    [SerializeField] private CharacterManager characterManager;

    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.characterManager = transform.parent.GetComponent<CharacterManager>();
    }

    protected override void OnClick()
    {
        base.OnClick();
        this.characterManager.BackOption();
    }
}
