using System;
using UnityEngine;

namespace GachiBird.UserInterface
{
    public sealed class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance { get; private set; }
        private void CreateSingleton()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        [Header("References")] 
        [SerializeField] private ScoreInterface _scoreInterface;
        [SerializeField] private SerializationManager _serializationManager;

        [Header("Settings")]
        [SerializeField] private int _amountOfPointsPerCheckpoint;
        
        public int Score { get; private set; }
        public int BestScore { get; private set; }
        
        public event Action PointGet;
        
        private void Awake()
        {
            CreateSingleton();
            
            Score = 0;
        }
        private void Start()
        {
            BestScore = _serializationManager.LoadBestScore();
        }
        
        public void GivePoints()
        {
            Score += _amountOfPointsPerCheckpoint;

            PointGet?.Invoke();
            
            TryToUpdateBestScore();
            
            _scoreInterface.RefreshScoreCounter(Score);
        }

        private void TryToUpdateBestScore()
        {
            if (Score > BestScore)
            {
                BestScore = Score;
                _serializationManager.SaveBestScore(BestScore);
            }
        }
        
        // public void ChangeAmountOfPointsPerCheckpoint(int amount)
        // {
        //     if (amount <= 0)
        //     {
        //         throw new ArgumentException();
        //     }
        //
        //     _amountOfPointsPerCheckpoint = amount;
        // }
    }
}
