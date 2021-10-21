using System;
using TMPro;
using UnityEngine;

namespace UserInterface
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

        #region References

        [Header("References")]
        [SerializeField] private GameCycle _gameCycle;
        [SerializeField] private SerializationManager _serializationManager;

        #endregion
        
        #region Objects
    
        [Header("Objects")]
        [SerializeField] private TextMeshProUGUI _scoreCounter;
    
        #endregion

        #region Settings

        [Header("Settings")]
        [SerializeField] private int _amountOfPointsPerCheckpoint;

        #endregion

        #region Properties
        
        private int _score;
        public int Score => _score;

        private int _bestScore;

        #endregion
        
        #region Events

        // TODO : maybe rename to OnCheckpointPass?
        public event Action OnPlusPoint;

        #endregion
    
        #region MonoBehaviour methods

        private void Awake()
        {
            CreateSingleton();
            
            _score = 0;

            _gameCycle.OnGameStart += ShowScoreCounter;
            _gameCycle.OnGameEnd += HideScoreCounter;
        }
        private void Start()
        {
            _bestScore = _serializationManager.LoadBestScore();
        }

        #endregion

        #region Methods

        private void RefreshScoreCounter()
        {
            _scoreCounter.text = _score.ToString();
        }
        private void ShowScoreCounter()
        {
            _scoreCounter.gameObject.SetActive(true);
            RefreshScoreCounter();
        }
        private void HideScoreCounter()
        {
            _scoreCounter.gameObject.SetActive(false);
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
    
        #endregion
    }
}
