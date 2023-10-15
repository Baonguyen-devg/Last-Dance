using System.Collections.Generic;
using UnityEngine;

public class CartoonStunEffect : RepeatMonoBehaviour
{
    [SerializeField] private float radius = 0.8f;
    [SerializeField] private float angularSpeed = 300f;
    [SerializeField] private Transform starsTransform;
    [SerializeField] private List<Transform> stars;
    
    private Vector3 headRight;
    private bool isStun;
    private const float DEG2_RAD = Mathf.Deg2Rad;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadStars();
    }

    private void LoadStars()
    {
        if (starsTransform != null) return;
        starsTransform = transform.Find("Stars");
        starsTransform.gameObject.SetActive(false);

        foreach (Transform star in starsTransform)
            stars.Add(star);
    }

    private void FixedUpdate()
    {
        if (!isStun) return;
        RotateStars();
    }

    private void RotateStars()
    {
        headRight = transform.right;

        float angularSpeedTime = angularSpeed * Time.time;
        float angleEachStar = 360.0f / stars.Count;
        
        for (int i = 0; i < stars.Count; i++)
        {
            float angle = angleEachStar*i + angularSpeedTime;
            float radian = angle * DEG2_RAD;

            float cosValue = Mathf.Cos(radian);
            float sinValue = Mathf.Sin(radian);

            float xOffset = cosValue * radius;
            float zOffset = sinValue * radius;

            Vector3 newPosition = transform.position + headRight * xOffset + new Vector3(0, 0, zOffset);
            stars[i].position = newPosition;
        }
    }

    public void SetOnStun(bool isOn)
    {
        isStun = isOn;
        starsTransform.gameObject.SetActive(isOn);
    }
}