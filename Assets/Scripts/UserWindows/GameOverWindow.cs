using GachiBird.Game;
using TMPro;
using UnityEngine;

namespace GachiBird.UserWindows
{
    public sealed class GameOverWindow : BaseWindow
    {
        [Header("References")] 
        [SerializeField] private GameCycle _gameCycle;
        [SerializeField] private ScoreHolderComponent _scoreHolder;
        
        [Header("Objects")]
        [SerializeField] private TMP_Text _currentScoreText;
        [SerializeField] private TMP_Text _bestScoreText;
        
        private void Awake()
        {
            _gameCycle.OnGameEnd += Show;
            _gameCycle.OnGameEnd += ShowResultScore;
        }

        private void ShowResultScore()
        {
            _currentScoreText.text = _scoreHolder.HeldItem.Score.ToString();
            _bestScoreText.text = _scoreHolder.HeldItem.BestScore.ToString();
        }
    }
}
