using System;
using DefaultNamespace;
using RepeatUtil.DesignPattern.SingletonPattern;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    //Bao
    [HideInInspector] public float DEFAULT_COUNTDOWN_START = 1.5f;
    private const float DEFAULT_COUNTDOWN_TO_RELAY = 2f;

    public event EventHandler OnGameOver;
    public event EventHandler OnGamePaused;
    public event EventHandler OnGameUnpaused;
    
    private enum State
    {
        CountdownToStart,
        GamePlaying,
        Pause,
        OnePlayerDead,
        EndGame,
    }
    
    private float countdownToStartPlay;
    private State state;
    private float countdownToReplay = DEFAULT_COUNTDOWN_TO_RELAY; 
    private bool isGamePause;

    protected override void Awake()
    {
        base.Awake();
        state = State.CountdownToStart;
        isGamePause = false;
    }

    private void Start()
    {
        this.countdownToStartPlay = DEFAULT_COUNTDOWN_START + UIManager.Instance.TimeAppearMainPanel;
        InputManager.Instance.OnPauseAction += InputManager_OnPauseAction;
    }

    private void InputManager_OnPauseAction(object sender, EventArgs e)
        => TogglePauseGame();

    public void TogglePauseGame()
    {
        if (IsGamePlaying() || IsGamePause())
        {
            isGamePause = !isGamePause;
            if (isGamePause) PauseGame();
            else UnpauseGame();
        }
    }

    private void PauseGame()
    {
        state = State.Pause;
        OnGamePaused?.Invoke(this, EventArgs.Empty);
    }
    
    public void UnpauseGame()
    {
        state = State.GamePlaying;
        OnGameUnpaused?.Invoke(this, EventArgs.Empty);
    }
    
    private void Update()
    {
        switch (state)
        {
            case State.CountdownToStart:
                countdownToStartPlay -= Time.deltaTime;
                if (countdownToStartPlay <= 0)
                {
                    countdownToStartPlay = DEFAULT_COUNTDOWN_START;
                    state = State.GamePlaying;
                }
                break;
            
            case State.OnePlayerDead:
                countdownToReplay -= Time.deltaTime;
                if (countdownToReplay <= 0)
                {
                    countdownToReplay = DEFAULT_COUNTDOWN_TO_RELAY;
                    state = State.EndGame;
                    EndGame();
                }
                break;
        }
    }

    public void PlayerOneWin()
    {
        state = State.OnePlayerDead;
        ScoreManager.Instance.IncreaseScorePlayerOne(1);
    }
    
    public void PlayerTwoWin()
    {
        state = State.OnePlayerDead;
        ScoreManager.Instance.IncreaseScorePlayerTwo(1);
    }
    
    //Bao
    public void SetStateCountDownToStart()
    {
        state = State.CountdownToStart;
        this.countdownToStartPlay = DEFAULT_COUNTDOWN_START;
    }

    public void EndGame()
    {
        if (ScoreManager.Instance.IsOnePlayerMaxScore()) this.GameOver();
        else this.PlayAgain();
    }
    
    public void GameOver() => OnGameOver?.Invoke(null, EventArgs.Empty);

    public void PlayAgain()
    {
        state = State.CountdownToStart;
        int numberScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(numberScene);
    }
    
    public bool IsGamePlaying() => state == State.GamePlaying;
    
    public bool IsOnePlayerDead() => state == State.OnePlayerDead;

    public bool IsGamePause() => state == State.Pause;
}

