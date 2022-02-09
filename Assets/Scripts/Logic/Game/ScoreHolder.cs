#nullable enable

using System;
using GachiBird.Environment;

namespace GachiBird.UserWindows
{
    public sealed class ScoreHolder : IScoreHolder
    {
        public int Score { get; private set; }
        public int BestScore { get; private set; }

        public event Action OnScoreChanged;
        public event Action OnBestScoreChanged;

        public ScoreHolder(IObstacleSpawner obstacleSpawner, int bestScore, int pointsPerCheckpoint)
        {
            obstacleSpawner.OnObstaclePassed += () => Add(pointsPerCheckpoint);
            BestScore = bestScore;
        }

        public void Add(int points)
        {
            Score += points;

            OnScoreChanged?.Invoke();

            TryUpdateBestScore();
        }

        private void TryUpdateBestScore()
        {
            if (Score > BestScore)
            {
                BestScore = Score;
                OnBestScoreChanged?.Invoke();
            }
        }
    }
}
