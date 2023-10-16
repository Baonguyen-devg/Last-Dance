using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButton : BaseButton
{
    protected override void DoActiveWhenSubmit()
    {
        Time.timeScale = 1;
        GameManager.Instance.GameUnPaused();
    }
}
