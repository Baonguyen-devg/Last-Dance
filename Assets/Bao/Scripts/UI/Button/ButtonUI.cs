using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUI : AutoMonoBehaviour
{
    [SerializeField] private Button buttonA;
    [SerializeField] private Button buttonD;
    [SerializeField] private Button buttonLeft;
    [SerializeField] private Button buttonRight;

    [SerializeField] private Button buttonExit;
    [SerializeField] private Button buttonFight;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) this.buttonA.onClick.Invoke();
        if (Input.GetKeyDown(KeyCode.D)) this.buttonD.onClick.Invoke();
        if (Input.GetKeyDown(KeyCode.LeftArrow)) this.buttonLeft.onClick.Invoke();
        if (Input.GetKeyDown(KeyCode.RightArrow)) this.buttonRight.onClick.Invoke();

        if (Input.GetKeyDown(KeyCode.Return)) this.buttonFight.onClick.Invoke();
        if (Input.GetKeyDown(KeyCode.Escape)) this.buttonExit.onClick.Invoke();
    }
}
