using AreYouFruits.Common.ComponentGeneration;
using UnityEngine;
using UnityEngine.UI;

namespace GachiBird.UserInterface.Windows
{
    public sealed class LeaderBoardWindow : BaseWindow
    {
#nullable disable
        [Header("Buttons")]
        [SerializeField] private Button _closeButton;
        
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

        protected override void Show()
        {
            base.Show();
            
            // TODO : Load leaderboard from GPS
        }
    }
}