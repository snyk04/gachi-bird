using System;
using GachiBird.Environment;

namespace GachiBird.Game
{
    public sealed class ScoreHolder : IScoreHolder
    {
        public int Score { get; private set; }
        public int HighScore { get; private set; }

        public event Action? OnScoreChanged;
        public event Action? OnHighScoreChanged;

        public ScoreHolder(IObstacleSpawner obstacleSpawner, int bestScore, int pointsPerCheckpoint)
        {
            obstacleSpawner.OnObstaclePassed += () => Add(pointsPerCheckpoint);
            HighScore = bestScore;
        }

        public void Add(int points)
        {
            Score += points;

            OnScoreChanged?.Invoke();

            TryUpdateBestScore();
        }

        private void TryUpdateBestScore()
        {
            if (Score > HighScore)
            {
                HighScore = Score;
                OnHighScoreChanged?.Invoke();
            }
        }
    }
}
