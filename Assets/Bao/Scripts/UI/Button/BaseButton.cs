using UnityEngine;
using UnityEngine.UI;

public class BaseButton : AutoMonoBehaviour
{
    [Header("Base Button"), Space(6)]
    [SerializeField] protected Button button;
    [SerializeField] protected AudioSource clickAudio;
    [SerializeField] protected Animator animator;

    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        this.animator = GetComponent<Animator>();
        this.clickAudio = GameObject.Find("Button Audio Source")?.GetComponent<AudioSource>();
        this.button = transform.GetComponent<Button>();
    }

    protected virtual void Start() => this.AddOnClickEvent();
    protected virtual void OnEnable() => animator.SetTrigger("Normal");

    protected virtual void AddOnClickEvent() => this.button.onClick.AddListener(this.OnClick);
    protected virtual void OnClick()
    {
        this.animator.SetTrigger("Selected");
        this.clickAudio.Play();
    }
}
