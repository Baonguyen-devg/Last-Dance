using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Animator))]
public abstract class BaseButton : AutoMonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private readonly string TRIGGER_SELECTED = "Selected";
    private readonly string TRIGGER_NORMAL = "Normal";

    #region Variables
    [Header("Base Button"), Space(6)]
    [SerializeField] protected Button button;
    [SerializeField] protected AudioSource clickAudio;
    [SerializeField] protected Animator animator;
    #endregion

    #region Load component methods
    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.animator = GetComponent<Animator>();
        this.clickAudio = GameObject.Find("Button Audio Source")?.GetComponent<AudioSource>();
        this.button = transform.GetComponent<Button>();
    }
    #endregion

    #region Main methods
    protected virtual void Start() => this.AddOnClickEvent();
    protected virtual void OnEnable() => animator.SetTrigger(TRIGGER_NORMAL);

    protected virtual void AddOnClickEvent() => this.button.onClick.AddListener(this.OnClick);
    protected virtual void OnClick()
    {
        this.animator.SetTrigger(TRIGGER_SELECTED);
        this.clickAudio.Play();
        this.DoActiveWhenSubmit();
    }

    protected abstract void DoActiveWhenSubmit();

    public void OnPointerEnter(PointerEventData eventData) =>
        EventSystem.current.SetSelectedGameObject(this.button.gameObject);

    public void OnPointerExit(PointerEventData eventData) { /* For Override */ }
    #endregion
}
