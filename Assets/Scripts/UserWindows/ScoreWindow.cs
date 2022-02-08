#nullable enable

using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Game;
using TMPro;
using UnityEngine;

namespace GachiBird.UserWindows
{
    public class ScoreWindow : BaseWindow
    {
#nullable disable
        [Header("References")]
        [SerializeField] private AbstractComponent<IGameCycle> _gameCycle;
        [SerializeField] private AbstractComponent<IScoreHolder> _scoreHolder;
        
        [Header("Objects")]
        [SerializeField] private TMP_Text _scoreCounter;
#nullable enable
        
        private void Awake()
        {
            _gameCycle.HeldItem.OnGameStart += Show;
            _gameCycle.HeldItem.OnGameEnd += Hide;

            _scoreHolder.HeldItem.OnScoreChanged += RefreshScoreCounter;
        }
        
        private void OnDestroy()
        {
            _gameCycle.HeldItem.OnGameStart -= Show;
            _gameCycle.HeldItem.OnGameEnd -= Hide;

            _scoreHolder.HeldItem.OnScoreChanged -= RefreshScoreCounter;
        }

        private void RefreshScoreCounter()
        {
            _scoreCounter.text = _scoreHolder.HeldItem.Score.ToString();
        }
    }
}
