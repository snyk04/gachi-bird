using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Game;
using TMPro;
using UnityEngine;

namespace GachiBird.UserWindows
{
    public sealed class ScoreWindow : BaseWindow
    {
#nullable disable
        [Header("References")]
        [SerializeField] private SerializedInterface<IComponent<IGameCycle>> _gameCycle;
        [SerializeField] private SerializedInterface<IComponent<IScoreHolder>> _scoreHolder;
        
        [Header("Objects")]
        [SerializeField] private TMP_Text _scoreCounter;
#nullable enable
        
        private void Awake()
        {
            _gameCycle.GetHeldItem().OnGameStart += Show;
            _gameCycle.GetHeldItem().OnGameEnd += Hide;

            _scoreHolder.GetHeldItem().OnScoreChanged += RefreshScoreCounter;
        }
        
        private void OnDestroy()
        {
            _gameCycle.GetHeldItem().OnGameStart -= Show;
            _gameCycle.GetHeldItem().OnGameEnd -= Hide;

            _scoreHolder.GetHeldItem().OnScoreChanged -= RefreshScoreCounter;
        }

        private void RefreshScoreCounter()
        {
            _scoreCounter.text = _scoreHolder.GetHeldItem().Score.ToString();
        }
    }
}
