namespace DefaultNamespace
{
    public class PlayerOneDustEffect : AbstractPlayerDustEffect
    {
        protected override bool GetKeyLeftDown() => InputManager.Instance.IsADown();

        protected override bool GetKeyUpDown() => InputManager.Instance.IsWDown();

        protected override bool GetKeyRightDown() => InputManager.Instance.IsDDown();
    }
}