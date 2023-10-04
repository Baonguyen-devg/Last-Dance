using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettingManager : AutoMonoBehaviour
{
    private const int DEFAULT_FPSGAME = 60;
    [SerializeField] private int FPSgame = DEFAULT_FPSGAME;

    protected virtual void Start() =>
        Application.targetFrameRate = this.FPSgame;
}
