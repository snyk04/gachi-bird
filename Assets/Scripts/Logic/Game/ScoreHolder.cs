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

        public ScoreHolder(IObstacleSpawner obstacleSpawner, IGameCycle gameCycle, int bestScore,
            int pointsPerCheckpoint)
        {
            HighScore = bestScore;

            obstacleSpawner.OnObstaclePassed += () => Add(pointsPerCheckpoint);
            gameCycle.OnGameEnd += TryUpdateBestScore;
        }

        public void Add(int points)
        {
            Score += points;

            OnScoreChanged?.Invoke();
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