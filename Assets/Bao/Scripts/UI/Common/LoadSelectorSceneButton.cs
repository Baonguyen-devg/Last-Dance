using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSelectorSceneButton : BaseButton
{
    private readonly string LOAD_SCENE_NAME = "Select Character Scene";
    protected override void DoActiveWhenSubmit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(LOAD_SCENE_NAME);
    }
}
