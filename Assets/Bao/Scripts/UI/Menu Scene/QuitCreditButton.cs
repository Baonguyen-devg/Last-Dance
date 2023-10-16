using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitCreditButton : BaseButton
{
    protected virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape))
            this.button.onClick.Invoke();
    }

    protected override void DoActiveWhenSubmit()
    {
        this.transform.parent.gameObject.SetActive(false);
    }
}
