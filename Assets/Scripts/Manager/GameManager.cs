using System;
using DefaultNamespace;
using RepeatUtil.DesignPattern.SingletonPattern;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    //Bao
    public float DEFAULT_COUNTDOWN_START = 5f;

    public event EventHandler OnGameOver;
    public event EventHandler OnGamePaused;
    public event EventHandler OnGameUnpaused;
    
    private enum State
    {
        CountdownToStart,
        GamePlaying,
        EndGame,
    }
    
    public enum PlayerWin
    {
        PlayerOne,
        PlayerTwo
    }
    
    private State state;
    private float coundownToStartPlay;
    private bool isGamePause = false;

    protected override void Awake()
    {
        base.Awake();
        state = State.CountdownToStart;
        this.coundownToStartPlay = DEFAULT_COUNTDOWN_START;
    }

    private void Start()
    {
        InputManager.Instance.OnPauseAction += InputManager_OnPauseAction;
    }

    private void InputManager_OnPauseAction(object sender, EventArgs e)
        => TogglePauseGame();

    public void TogglePauseGame()
    {
        isGamePause = !isGamePause;
        if (isGamePause) {
            Time.timeScale = 0;
            OnGamePaused?.Invoke(this, EventArgs.Empty);
        }else {
            Time.timeScale = 1;
            OnGameUnpaused?.Invoke(this, EventArgs.Empty);
        }
    }
    
    private void Update()
    {
        switch (state)
        {
            case State.CountdownToStart:
                coundownToStartPlay -= Time.deltaTime;
                if (coundownToStartPlay <= 0)
                {
                    coundownToStartPlay = DEFAULT_COUNTDOWN_START;
                    state = State.GamePlaying;
                }
                break;
            
            case State.GamePlaying:
                break;
            
            
            case State.EndGame:
                break;
        }
    }

    public bool IsGamePlaying() => state == State.GamePlaying;
    
    public bool IsCountDownToStartIsActive() => state == State.CountdownToStart;
    
    public bool IsEndGame() => state == State.EndGame;

    public float GetCoundownToStartTimer() => coundownToStartPlay;

    public void GameOver()
    {
        state = State.EndGame;
        OnGameOver?.Invoke(this, EventArgs.Empty);
    }

    public void PlayerOneWin()
    {
        state = State.CountdownToStart;
        ScoreManager.Instance.IncreaseScorePlayerOne(1);
        if (ScoreManager.Instance.IsOnePlayerMaxScore()) GameOver();   
    }
    
    public void PlayerTwoWin()
    {
        state = State.CountdownToStart;
        ScoreManager.Instance.IncreaseScorePlayerTwo(1);
        if (ScoreManager.Instance.IsOnePlayerMaxScore()) GameOver();
    }
}

