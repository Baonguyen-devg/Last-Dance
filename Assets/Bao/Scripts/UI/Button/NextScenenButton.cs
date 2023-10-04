using UnityEngine.SceneManagement;

public class NextScenenButton : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();
        int indexSceneNext = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(indexSceneNext);
    }
}
