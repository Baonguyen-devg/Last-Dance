using System;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxMovement : AutoMonoBehaviour
{
    #region Variables
    [Header("[ Component ]"), Space(6)]
    [SerializeField] private Transform cam;

    [Header("[ Movement's informations ]"), Space(6)]
    [SerializeField] private Vector3 direction = Vector3.left;
    [SerializeField] private float len = default;
    [SerializeField] private float posCamera = default;
    [SerializeField] private float speed = 0.01f;
    #endregion

    #region Load component methods
    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.cam = GameObject.Find("Main Camera").transform;
        this.len = GetComponent<SpriteRenderer>().bounds.size.x;
        this.posCamera = this.cam.position.x;
    }
    #endregion

    #region Main methods
    private void Update()
    {
        this.Move();
        var posX = transform.position.x;
        if (posX > this.posCamera + this.len) posX = this.posCamera - this.len;
        else if (posX < this.posCamera - this.len) posX = this.posCamera + this.len;
        else return;

        this.MoveToPos(posX);
    }

    protected virtual void Move()
    {
        Vector3 newPos = transform.position + this.direction;
        transform.position = Vector3.Lerp(transform.position, newPos, this.speed);
    }

    private void MoveToPos(
       float posX
    ) {
        Vector3 newPos = new Vector3(posX, transform.position.y, transform.position.z);
        transform.position = newPos;
    }
    #endregion
}
