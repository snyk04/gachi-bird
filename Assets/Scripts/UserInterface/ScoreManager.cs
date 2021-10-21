using System;
using GachiBird.UserInterface;
using TMPro;
using UnityEngine;

namespace UserInterface
{
    public sealed class ScoreManager : GameInterface
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
        [SerializeField] private GameCycle _gameCycle;
        [SerializeField] private SerializationManager _serializationManager;
        
        [Header("Objects")]
        [SerializeField] private TextMeshProUGUI _scoreCounter;
        
        [Header("Settings")]
        [SerializeField] private int _amountOfPointsPerCheckpoint;
        
        private int _score;
        public int Score => _score;

        private int _bestScore;
        
        // TODO : maybe rename to OnCheckpointPass?
        public event Action OnPlusPoint;
        
        private void Awake()
        {
            CreateSingleton();
            
            _score = 0;

            _gameCycle.OnGameStart += Show;
            _gameCycle.OnGameEnd += Hide;
        }
        private void Start()
        {
            _bestScore = _serializationManager.LoadBestScore();
        }
        
        private void RefreshScoreCounter()
        {
            _scoreCounter.text = _score.ToString();
        }

        public void ChangeAmountOfPointsPerCheckpoint(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException();
            }
        
            _amountOfPointsPerCheckpoint = amount;
        }

        private void TryToUpdateBestScore()
        {
            if (_score > _bestScore)
            {
                _bestScore = _score;
                _serializationManager.SaveBestScore(_bestScore);
            }
        }
        public void GivePoints()
        {
            _score += _amountOfPointsPerCheckpoint;
            
            OnPlusPoint?.Invoke();
            
            TryToUpdateBestScore();
            RefreshScoreCounter();
        }
    }
}
