using GachiBird.UserInterface;
using TMPro;
using UnityEngine;

namespace UserInterface
{
    public sealed class GameOverInterface : GameInterface
    {
        [Header("References")] 
        [SerializeField] private GameCycle _gameCycle;
        [SerializeField] private ScoreManager _scoreManager;
        [SerializeField] private SerializationManager _serializationManager;
        
        [Header("Objects")]
        [SerializeField] private TextMeshProUGUI _currentScoreText;
        [SerializeField] private TextMeshProUGUI _bestScoreText;
        
        private void Awake()
        {
            _gameCycle.OnGameEnd += Show;
            _gameCycle.OnGameEnd += ShowResultScore;
        }

        private void ConfigureCurrentScoreContainer()
        {
            TextManager.SetText(_currentScoreText, _scoreManager.Score.ToString());
        }
        private void ConfigureBestScoreContainer()
        {
            TextManager.SetText(_bestScoreText, _serializationManager.LoadBestScore().ToString());
        }
        private void ShowResultScore()
        {
            ConfigureCurrentScoreContainer();
            ConfigureBestScoreContainer();
        }
    }
}
