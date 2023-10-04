using UnityEngine;

public class CharacterCarousel : AutoMonoBehaviour 
{
    private const float DEFAULT_RADIUS = 1.5f;
    private const float DEFAULT_SPEED_ROTATE = 0.01f;
    private const float ANGLE_DEVIATION = -90;

    [Header("[ Component ]"), Space(6)]
    [SerializeField] private CharacterManager characterManager;
    [SerializeField] private Transform holder;

    [Header("[ Details about carousel ]"), Space(6)]
    [SerializeField] private float radius = DEFAULT_RADIUS;
    [SerializeField] private float angle;
    [SerializeField] private float anglePresent;

    [SerializeField] private bool isRight = false;
    [SerializeField] private float speedRotate = DEFAULT_SPEED_ROTATE;
    [SerializeField] private float rateRotate = 2f;

    [ContextMenu("Load Component")] 
    protected override void LoadComponent() 
    {
        this.holder = transform.Find("Holder");
        this.characterManager = transform.parent.GetComponent<CharacterManager>();
    }

    protected virtual void Start() 
    {
        this.angle = (float )360 / (this.characterManager.CharacterLoader.Characters.Count);
        this.SetUpPositionCharacter();
        this.Rotate(ANGLE_DEVIATION, 0);
    }

    private void Update() 
    {
        if (this.anglePresent == 0) return;
        this.speedRotate = this.speedRotate - Time.deltaTime;
        if (this.speedRotate > 0) return;

        this.speedRotate = DEFAULT_SPEED_ROTATE;
        float nextStep = Mathf.Min(this.rateRotate, Mathf.Abs(this.anglePresent));

        this.UpdateAngleStatus(nextStep);
        if (this.isRight) this.Rotate(nextStep, this.characterManager.Count);
        else this.Rotate(-nextStep, this.characterManager.Count);

    }

    private void UpdateAngleStatus(float angle)
    {
        if (this.anglePresent > 0)
            (this.isRight, this.anglePresent) = (true, this.anglePresent - angle);
        else if (this.anglePresent < 0)
            (this.isRight, this.anglePresent) = (false, this.anglePresent + angle);
    }

    public virtual void RequestRotate(
        bool isRight
    ) {
        if (isRight) this.anglePresent = this.anglePresent + this.angle;
        else this.anglePresent = this.anglePresent - this.angle;
    } 

    private void SetUpPositionCharacter() 
    {
        int count = 0;
        foreach (Transform character in this.characterManager.CharacterLoader.Characters) 
        {
            float anglePresent = this.angle * count;
            float x = Mathf.Cos(anglePresent * Mathf.Deg2Rad);
            float y = Mathf.Sin(anglePresent *  Mathf.Deg2Rad);
            count = count + 1;

            float hypotenuseLength = Mathf.Sqrt(x * x + y * y);
            float rate = this.radius / hypotenuseLength;
            character.position += new Vector3(x * rate, y * rate, 0);
        }
    }

    private float CalculateAngle(
        Vector3 pointA, 
        Vector3 pointB, 
        Vector3 pointC
     ) {
        Vector3 vectorAB = pointB - pointA;
        Vector3 vectorCB = pointB - pointC;

        float magnitudeAB = vectorAB.magnitude;
        float magnitudeCB = vectorCB.magnitude;

        float dotProduct = Vector3.Dot(vectorAB, vectorCB);
        float angleRadians = Mathf.Acos(dotProduct / (magnitudeAB * magnitudeCB));
        return angleRadians * Mathf.Rad2Deg + ANGLE_DEVIATION;
    }

    private void Rotate(
        float number, 
        int count    
    ) {
        this.RotateHolder(number);
        foreach (Transform character in this.characterManager.CharacterLoader.Characters) 
        {
            Animator animator = character.transform.Find("Model").GetComponent<Animator>();
            if (count-- != 0) animator.SetBool("Chosen", false);
            else animator.SetBool("Chosen", true);

            Vector3 cPosition = new Vector3(0, character.position.y, 0);
            float angle = this.CalculateAngle(character.position, Vector3.zero, cPosition);
            character.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void RotateHolder(
        float number
    ) {
        float eulerZ = this.holder.rotation.eulerAngles.z + number;
        Vector3 newEuler = new Vector3(0, 0, eulerZ);
        this.holder.rotation = Quaternion.Euler(newEuler.x, newEuler.y, newEuler.z);
    }
}
