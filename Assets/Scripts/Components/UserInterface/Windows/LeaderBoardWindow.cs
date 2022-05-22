using AreYouFruits.Common.ComponentGeneration;
using UnityEngine;
using UnityEngine.UI;

namespace GachiBird.UserInterface.Windows
{
    public class LeaderBoardWindow : BaseWindow
    {
#nullable disable
        [SerializeField] private Button _closeButton;
#nullable enable

        private void Awake()
        {
            _userInterfaceCycle.GetHeldItem().OnLeaderBoardWindowShow += () =>
            {
                Show();
                Social.ShowLeaderboardUI();
            };
            _userInterfaceCycle.GetHeldItem().OnLeaderBoardWindowHide += Hide;
            
            _closeButton.onClick.AddListener(() =>
            {
                _userInterfaceCycle.GetHeldItem().HideLeaderBoardWindow();
                _userInterfaceCycle.GetHeldItem().ShowGameOverWindow();
            });
        }
    }
}