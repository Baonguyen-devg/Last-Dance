public class ContinueButton : BaseButton
{
    protected override void DoActiveWhenSubmit() 
        => GameManager.Instance.UnpauseGame();
}
