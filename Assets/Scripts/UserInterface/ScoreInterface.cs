using TMPro;
using UnityEngine;

namespace GachiBird.UserInterface
{
    public class ScoreInterface : GameInterface
    {
        [Header("References")]
        [SerializeField] private GameCycle _gameCycle;
        
        [Header("Objects")]
        [SerializeField] private TMP_Text _scoreCounter;

        private void Awake()
        {
            _gameCycle.OnGameStart += Show;
            _gameCycle.OnGameEnd += Hide;
        }

        public void RefreshScoreCounter(int score)
        {
            TextManager.ChangeText(_scoreCounter, score.ToString());
        }
    }
}
