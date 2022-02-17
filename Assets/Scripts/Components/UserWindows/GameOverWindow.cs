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
        [SerializeField] private SerializedInterface<IComponent<IGameCycle>> _gameCycle;
        [SerializeField] private SerializedInterface<IComponent<IScoreHolder>> _scoreHolder;
        
        [Header("Objects")]
        [SerializeField] private TMP_Text _currentScoreText;
        [SerializeField] private TMP_Text _bestScoreText;
#nullable enable
        
        private void Awake()
        {
            _gameCycle.GetHeldItem().OnGameEnd += Show;
            _gameCycle.GetHeldItem().OnGameEnd += ShowResultScore;
            
            _okButton.onClick.AddListener(() => _gameCycle.GetHeldItem().RestartGame());
        }

        private void ShowResultScore()
        {
            _currentScoreText.text = _scoreHolder.GetHeldItem().Score.ToString();
            _bestScoreText.text = _scoreHolder.GetHeldItem().HighScore.ToString();
        }
    }
}
