using System;
using RepeatUtil.DesignPattern.SingletonPattern;

namespace DefaultNamespace
{
    public class ScoreManager : Singleton<ScoreManager>
    {
        public event Action<int> OnScorePlayerOneChanged;
        public event Action<int> OneScorePlayerTwoChanged;
        
        private int scorePlayerOne;
        private int scorePlayerTwo;
        private const int MAX_SCORE = 1;

        public int ScorePlayerOne => this.scorePlayerOne;
        public int ScorePlayerTwo => this.scorePlayerTwo;

        private void Start()
        {
            scorePlayerOne = scorePlayerTwo = 0;
        }

        public void IncreaseScorePlayerOne(int score)
        {
            scorePlayerOne += score;
            OnScorePlayerOneChanged?.Invoke(scorePlayerOne);
        }
        
        public void IncreaseScorePlayerTwo(int score)
        {
            scorePlayerTwo += score;
            OneScorePlayerTwoChanged?.Invoke(scorePlayerTwo);
        }

        public bool IsPlayerOneMaxScore() => scorePlayerOne == MAX_SCORE;
        
        public bool IsOnePlayerMaxScore() => scorePlayerOne == MAX_SCORE || scorePlayerTwo == MAX_SCORE;
    }
}