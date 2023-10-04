using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitCreditButton : BaseButton
{
    [SerializeField] private Transform buttons;

    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.buttons = GameObject.Find("Canvas").transform.Find("Menu Panel").Find("Buttons");
    }

    protected virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape))
            this.button.onClick.Invoke();
    }

    protected override void OnClick()
    {
        base.OnClick();
        this.transform.parent.gameObject.SetActive(false);
        this.buttons.gameObject.SetActive(true);
    }
}
