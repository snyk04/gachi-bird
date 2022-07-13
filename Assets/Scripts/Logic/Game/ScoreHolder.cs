using System;
using GachiBird.Environment;
using GachiBird.Serialization;

namespace GachiBird.Game
{
    public sealed class ScoreHolder : IScoreHolder
    {
        public int Score { get; private set; }
        public int HighScore { get; private set; }

        public event Action? OnScoreChanged;
        public event Action? OnHighScoreChanged;

        public ScoreHolder(
            IObstacleSpawner obstacleSpawner, IGameCycle gameCycle, IGameLoader gameLoader, int pointsPerCheckpoint
        )
        {
            HighScore = gameLoader.BestScore;

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
