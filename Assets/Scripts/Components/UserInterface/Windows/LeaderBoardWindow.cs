using AreYouFruits.Common.Collections;
using AreYouFruits.Common.ComponentGeneration;
using GachiBird.LeaderBoard;
using UnityEngine;
using UnityEngine.UI;

namespace GachiBird.UserInterface.Windows
{
    public class LeaderBoardWindow : BaseWindow
    {
#nullable disable
        [Header("Buttons")]
        [SerializeField] private Button _closeButton;

        [Header("References")]
        [SerializeField] private SerializedInterface<IComponent<ILeaderBoard>> _leaderBoard;
        
        [Header("Objects")]
        [SerializeField] private Text _text;
#nullable enable

        private void Awake()
        {
            _userInterfaceCycle.GetHeldItem().OnLeaderBoardShow += Show;
            _userInterfaceCycle.GetHeldItem().OnLeaderBoardHide += Hide;

            _closeButton.onClick.AddListener(() =>
            {
                _userInterfaceCycle.GetHeldItem().HideLeaderBoard();
                _userInterfaceCycle.GetHeldItem().ShowGameOverWindow();
            });
        }

        public override void Show()
        {
            base.Show();
            DrawLeaderBoard();
        }

        private void DrawLeaderBoard()
        {
            _text.text = "";
            foreach ((string? userName, long bestScore) in _leaderBoard.GetHeldItem().BestScores)
            {
                _text.text += $"{userName} - {bestScore}\n";
            }
        }
    }
}