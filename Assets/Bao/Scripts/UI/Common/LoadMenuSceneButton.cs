using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenuSceneButton : BaseButton
{
    private readonly string LOAD_SCENE_NAME = "Menu";
    protected override void DoActiveWhenSubmit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(LOAD_SCENE_NAME);
    }
}
