using GachiBird.Game;
using TMPro;
using UnityEngine;

namespace GachiBird.UserWindows
{
    public class ScoreWindow : BaseWindow
    {
        [Header("References")]
        [SerializeField] private GameCycle _gameCycle;
        [SerializeField] private ScoreHolderComponent _scoreHolder;
        
        [Header("Objects")]
        [SerializeField] private TMP_Text _scoreCounter;

        private void Awake()
        {
            _gameCycle.OnGameStart += Show;
            _gameCycle.OnGameEnd += Hide;

            _scoreHolder.HeldItem.OnScoreChanged += RefreshScoreCounter;
        }
        
        private void OnDestroy()
        {
            _gameCycle.OnGameStart -= Show;
            _gameCycle.OnGameEnd -= Hide;

            _scoreHolder.HeldItem.OnScoreChanged -= RefreshScoreCounter;
        }

        private void RefreshScoreCounter()
        {
            _scoreCounter.text = _scoreHolder.HeldItem.Score.ToString();
        }
    }
}
