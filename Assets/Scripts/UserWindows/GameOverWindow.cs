#nullable enable

using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Game;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GachiBird.UserWindows
{
    public sealed class GameOverWindow : BaseWindow
    {
#nullable disable
        [Header("Buttons")] 
        [SerializeField] private Button _okButton;
        
        [Header("References")] 
        [SerializeField] private AbstractComponent<IGameCycle> _gameCycle;
        [SerializeField] private AbstractComponent<IScoreHolder> _scoreHolder;
        
        [Header("Objects")]
        [SerializeField] private TMP_Text _currentScoreText;
        [SerializeField] private TMP_Text _bestScoreText;
#nullable enable
        
        private void Awake()
        {
            _gameCycle.HeldItem.OnGameEnd += Show;
            _gameCycle.HeldItem.OnGameEnd += ShowResultScore;
            
            _okButton.onClick.AddListener(() => _gameCycle.HeldItem.RestartGame());
        }

        private void ShowResultScore()
        {
            _currentScoreText.text = _scoreHolder.HeldItem.Score.ToString();
            _bestScoreText.text = _scoreHolder.HeldItem.BestScore.ToString();
        }
    }
}
