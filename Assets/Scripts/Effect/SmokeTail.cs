using DefaultNamespace;
using UnityEngine;
using Random = UnityEngine.Random;

public class SmokeTail : MonoBehaviour
{
    [SerializeField] private Sprite[] smokeSprites;
    [SerializeField] private float scaleDecreaseOverFixedUpdateTime;
    [SerializeField] private float alphaOverFixedUpdateTime;

    private SpriteRenderer spriteRenderer;
    private Vector3 defaultScale;
    private Color defaultColor;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultScale = transform.localScale;
        defaultColor = spriteRenderer.color;
    }
    
    private void OnEnable()
    {
        spriteRenderer.sprite = GetRandomSprite(); 
        transform.localScale = defaultScale;
        spriteRenderer.color = defaultColor;
    }

    private Sprite GetRandomSprite()
        => smokeSprites[Random.Range(0, smokeSprites.Length)];
    
    private void FixedUpdate()
    {
        DecreaseSizeAndAlpha();
        
        if (!IsDisappear()) return;
        EffectPoolingObject.Instance.Despawn(this.transform);
    }

    private void DecreaseSizeAndAlpha()
    {
        float currentAlpha = spriteRenderer.color.a;
        currentAlpha -= alphaOverFixedUpdateTime * Time.fixedDeltaTime;
        spriteRenderer.color = new Color(defaultColor.r, defaultColor.g, defaultColor.b, currentAlpha);
        transform.localScale -= Vector3.one * scaleDecreaseOverFixedUpdateTime * Time.fixedDeltaTime;
    }
    
    private bool IsDisappear() 
        => spriteRenderer.color.a <= 0 || transform.localScale.x <= 0;
}