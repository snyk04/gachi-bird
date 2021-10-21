using GachiBird.Game;
using TMPro;
using UnityEngine;

namespace GachiBird.UserInterface
{
    public sealed class GameOverInterface : GameInterface
    {
        [Header("References")] 
        [SerializeField] private GameCycle _gameCycle;
        [SerializeField] private ScoreManager _scoreManager;
        
        [Header("Objects")]
        [SerializeField] private TMP_Text _currentScoreText;
        [SerializeField] private TMP_Text _bestScoreText;
        
        private void Awake()
        {
            _gameCycle.OnGameEnd += Show;
            _gameCycle.OnGameEnd += ShowResultScore;
        }

        private void ConfigureCurrentScoreContainer()
        {
            TextManager.ChangeText(_currentScoreText, _scoreManager.Score.ToString());
        }
        private void ConfigureBestScoreContainer()
        {
            TextManager.ChangeText(_bestScoreText, _scoreManager.BestScore.ToString());
        }
        private void ShowResultScore()
        {
            ConfigureCurrentScoreContainer();
            ConfigureBestScoreContainer();
        }
    }
}
