using System;
using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Environment;
using GachiBird.Serialization;
using UnityEngine;

namespace GachiBird.UserWindows
{
    public sealed class ScoreHolderComponent : AbstractComponent<ScoreHolder>
    {
        [Header("References")]
        [SerializeField] private SerializationManagerComponent _serializationManager;
        [SerializeField] private ObstacleSpawnerComponent _obstacleSpawner;
        [SerializeField] private int _pointsPerCheckpoint;

        protected override ScoreHolder Create()
        {
            return new ScoreHolder(
                _obstacleSpawner.HeldItem,
                _serializationManager.HeldItem.LoadBestScore(),
                _pointsPerCheckpoint
            );
        }
    }

    public class ScoreHolder
    {
        public int Score { get; private set; }
        public int BestScore { get; private set; }

        public event Action OnScoreChanged;
        public event Action OnBestScoreChanged;

        public ScoreHolder(ObstacleSpawner obstacleSpawner, int bestScore, int pointsPerCheckpoint)
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
