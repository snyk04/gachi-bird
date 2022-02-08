#nullable enable

using GachiBird.Game;
using TMPro;
using UnityEngine;

namespace GachiBird.UserWindows
{
    public class ScoreWindow : BaseWindow
    {
#nullable disable
        [Header("References")]
        [SerializeField] private GameCycleComponent _gameCycle;
        [SerializeField] private ScoreHolderComponent _scoreHolder;
        
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
