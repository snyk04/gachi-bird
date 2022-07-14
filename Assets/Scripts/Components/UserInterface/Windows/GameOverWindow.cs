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
        [SerializeField] private Button _musicListButton;

        [Header("References")]
        [SerializeField] private SerializedInterface<IComponent<IGameCycle>> _gameCycle;
        [SerializeField] private SerializedInterface<IComponent<IScoreHolder>> _scoreHolder;

        [Header("Objects")]
        [SerializeField] private TMP_Text _currentScoreText;
        [SerializeField] private TMP_Text _bestScoreText;
    #nullable enable

        private void Awake()
        {
            _userInterfaceCycle.GetHeldItem().OnWindowShow += windowType =>
            {
                if (windowType == WindowType.GameOver)
                {
                    Show();
                }
            };

            _userInterfaceCycle.GetHeldItem().OnWindowHide += windowType =>
            {
                if (windowType == WindowType.GameOver)
                {
                    Hide();
                }
            };

            _okButton.onClick.AddListener(() => _gameCycle.GetHeldItem().RestartGame());

            _shopButton.onClick.AddListener(
                () =>
                {
                    _userInterfaceCycle.GetHeldItem().HideWindow(WindowType.GameOver);
                    _userInterfaceCycle.GetHeldItem().ShowWindow(WindowType.Shop);
                }
            );

            _musicListButton.onClick.AddListener(
                () =>
                {
                    _userInterfaceCycle.GetHeldItem().HideWindow(WindowType.GameOver);
                    _userInterfaceCycle.GetHeldItem().ShowWindow(WindowType.MusicList);
                }
            );
        }

        public override void Show()
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
