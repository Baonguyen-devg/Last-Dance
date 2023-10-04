using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneButton : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();
        int indexSceneNext = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(indexSceneNext);
    }
}
