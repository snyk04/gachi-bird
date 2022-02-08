#nullable enable

using GachiBird.Game;
using TMPro;
using UnityEngine;

namespace GachiBird.UserWindows
{
    public sealed class GameOverWindow : BaseWindow
    {
#nullable disable
        [Header("References")] 
        [SerializeField] private GameCycleComponent _gameCycle;
        [SerializeField] private ScoreHolderComponent _scoreHolder;
        
        [Header("Objects")]
        [SerializeField] private TMP_Text _currentScoreText;
        [SerializeField] private TMP_Text _bestScoreText;
#nullable enable
        
        private void Awake()
        {
            _gameCycle.HeldItem.OnGameEnd += Show;
            _gameCycle.HeldItem.OnGameEnd += ShowResultScore;
        }

        private void ShowResultScore()
        {
            _currentScoreText.text = _scoreHolder.HeldItem.Score.ToString();
            _bestScoreText.text = _scoreHolder.HeldItem.BestScore.ToString();
        }
    }
}
