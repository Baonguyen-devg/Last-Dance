using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGameButton : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();
        Application.Quit();
    }
}
