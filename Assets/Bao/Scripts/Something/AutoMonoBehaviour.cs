using UnityEngine;

public class AutoMonoBehaviour : MonoBehaviour
{
    protected virtual void Reset() => this.LoadComponent();
    protected virtual void Awake() => this.LoadComponent();

    protected virtual void LoadComponent() { /* For Override */ }
}
