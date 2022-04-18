using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Game;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GachiBird.UserInterface.Windows
{
    public sealed class GameOverWindow : BaseWindow
    {
#nullable disable
        [Header("Buttons")] 
        [SerializeField] private Button _okButton;
        [SerializeField] private Button _shopButton;
        
        [Header("References")] 
        [SerializeField] private SerializedInterface<IComponent<IGameCycle>> _gameCycle;
        [SerializeField] private SerializedInterface<IComponent<IScoreHolder>> _scoreHolder;
        
        [Header("Objects")]
        [SerializeField] private TMP_Text _currentScoreText;
        [SerializeField] private TMP_Text _bestScoreText;
#nullable enable
        
        private void Awake()
        {
            _userInterfaceCycle.GetHeldItem().OnGameOverWindowShow += Show;
            _userInterfaceCycle.GetHeldItem().OnGameOverWindowHide += Hide;
            
            _okButton.onClick.AddListener(() => _gameCycle.GetHeldItem().RestartGame());
            _shopButton.onClick.AddListener(() =>
            {
                _userInterfaceCycle.GetHeldItem().HideGameOverWindow();
                _userInterfaceCycle.GetHeldItem().ShowShopWindow();
            });
        }

        protected override void Show()
        {
            base.Show();
            ShowResultScore();
        }

        private void ShowResultScore()
        {
            _currentScoreText.text = _scoreHolder.GetHeldItem().Score.ToString();
            _bestScoreText.text = _scoreHolder.GetHeldItem().HighScore.ToString();
        }
    }
}
