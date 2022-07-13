using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Game;
using TMPro;
using UnityEngine;

namespace GachiBird.UserInterface.Windows
{
    public sealed class ScoreWindow : BaseWindow
    {
#nullable disable
        [Header("References")]
        [SerializeField] private SerializedInterface<IComponent<IScoreHolder>> _scoreHolder;
        
        [Header("Objects")]
        [SerializeField] private TMP_Text _scoreCounter;
#nullable enable
        
        private void Awake()
        {
            _userInterfaceCycle.GetHeldItem().OnWindowShow += windowType =>
            {
                if (windowType == WindowType.Score)
                {
                    Show();
                }
            };
            
            _userInterfaceCycle.GetHeldItem().OnWindowHide += windowType =>
            {
                if (windowType == WindowType.Score)
                {
                    Hide();
                }
            };

            _scoreHolder.GetHeldItem().OnScoreChanged += RefreshScoreCounter;
        }

        private void RefreshScoreCounter()
        {
            _scoreCounter.text = _scoreHolder.GetHeldItem().Score.ToString();
        }
    }
}
