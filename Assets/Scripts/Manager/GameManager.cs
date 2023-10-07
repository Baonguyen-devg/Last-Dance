using System;
using DefaultNamespace;
using RepeatUtil.DesignPattern.SingletonPattern;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    //Bao
    public float DEFAULT_COUNTDOWN_START = 3f;

    public event EventHandler OnGameOver;
    public event EventHandler OnGamePaused;
    public event EventHandler OnGameUnpaused;
    
    private enum State
    {
        CountdownToStart,
        GamePlaying,
        OnePlayerDead,
        EndGame,
    }
    
    private State state;
    [SerializeField] private float countdownToStartPlay;
    private float countdownToReplay; // Thay doi lai 
    private bool isGamePause = false;

    protected override void Awake()
    {
        base.Awake();
        state = State.CountdownToStart;
    }

    private void Start()
    {
        this.countdownToStartPlay = DEFAULT_COUNTDOWN_START + UIController.Instance.TimeAppearMainPanel;
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
                countdownToStartPlay -= Time.deltaTime;
                if (countdownToStartPlay <= 0)
                {
                    // DEFAULT_COUNTDOWN_START thay doi lai
                    countdownToStartPlay = DEFAULT_COUNTDOWN_START;
                    state = State.GamePlaying;
                }
                break;
            
            case State.GamePlaying:
                break;
            
            case State.OnePlayerDead:
                countdownToReplay -= Time.deltaTime;
                if (countdownToReplay <= 0)
                {
                    countdownToReplay = 3;
                    state = State.EndGame;
                }
                break;
            
            case State.EndGame:
                break;
        }
        Debug.Log(state.ToString());
    }
    

    public void GameOver()
    {
        state = State.EndGame;
        OnGameOver?.Invoke(this, EventArgs.Empty);
    }

    public void PlayerOneWin()
    {
        state = State.OnePlayerDead;
        ScoreManager.Instance.IncreaseScorePlayerOne(1);
        if (ScoreManager.Instance.IsOnePlayerMaxScore()) GameOver();   
    }
    
    public void PlayerTwoWin()
    {
        state = State.OnePlayerDead;
        ScoreManager.Instance.IncreaseScorePlayerTwo(1);
        if (ScoreManager.Instance.IsOnePlayerMaxScore()) GameOver();
    }
    
    public bool IsGamePlaying() => state == State.GamePlaying;
    
    public bool IsCountDownToStartIsActive() => state == State.CountdownToStart;
    
    public bool IsOnePlayerDead() => state == State.OnePlayerDead;

    public bool IsEndGame() => state == State.EndGame;
    
    public float GetCoundownToStartTimer() => countdownToStartPlay;

    public void PlayeAgain() => state = State.CountdownToStart; 
}

