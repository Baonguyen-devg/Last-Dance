namespace DefaultNamespace
{
    public class PlayerTwoDustEffect : AbstractPlayerDustEffect
    {
        protected override bool GetKeyLeftDown() => InputManager.Instance.IsLeftArrowDown();

        protected override bool GetKeyUpDown() => InputManager.Instance.IsUpArrowDown();

        protected override bool GetKeyRightDown() => InputManager.Instance.IsRightArrowDown();
    }
}