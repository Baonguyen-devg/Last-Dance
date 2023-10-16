using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScenenButton : BaseButton
{
    protected override void DoActiveWhenSubmit()
    {
        Time.timeScale = 1;
        int indexSceneNext = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(indexSceneNext);
    }
}
