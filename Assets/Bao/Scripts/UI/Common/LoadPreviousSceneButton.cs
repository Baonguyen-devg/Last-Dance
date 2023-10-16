using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPreviousSceneButton : BaseButton
{
    protected override void DoActiveWhenSubmit()
    {
        Time.timeScale = 1;
        int indexSceneNext = SceneManager.GetActiveScene().buildIndex - 1;
        SceneManager.LoadScene(indexSceneNext);
    }
}
