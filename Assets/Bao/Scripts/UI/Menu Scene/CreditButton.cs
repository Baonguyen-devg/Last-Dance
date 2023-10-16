using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditButton : BaseButton
{
    [SerializeField] private Transform creditPanel;
    [SerializeField] private Transform buttons;

    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.creditPanel = GameObject.Find("Canvas").transform.Find("Credit Panel");
        this.buttons = transform.parent;
    }

    protected override void DoActiveWhenSubmit()
    {
        this.animator.SetTrigger("Normal");
        this.creditPanel.gameObject.SetActive(true);
        this.buttons.gameObject.SetActive(false);
    }
}
