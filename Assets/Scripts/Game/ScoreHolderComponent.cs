#nullable enable

using System;
using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Environment;
using GachiBird.Serialization;
using UnityEngine;

namespace GachiBird.UserWindows
{
    public sealed class ScoreHolderComponent : AbstractComponent<IScoreHolder>
    {
#nullable disable
        [Header("References")]
        [SerializeField] private AbstractComponent<ISerializationManager> _serializationManager;
        [SerializeField] private AbstractComponent<IObstacleSpawner> _obstacleSpawner;
        [SerializeField] private int _pointsPerCheckpoint;
#nullable enable
        
        protected override IScoreHolder Create()
        {
            return new ScoreHolder(
                _obstacleSpawner.HeldItem,
                _serializationManager.HeldItem.LoadBestScore(),
                _pointsPerCheckpoint
            );
        }
    }

    public interface IScoreHolder
    {
        public int Score { get; }
        public int BestScore { get; }

        public event Action OnScoreChanged;
        public event Action OnBestScoreChanged;

        public void Add(int points);
    }

    public class ScoreHolder : IScoreHolder
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
