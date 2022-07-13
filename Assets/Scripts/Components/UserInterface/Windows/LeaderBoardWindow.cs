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
            _userInterfaceCycle.GetHeldItem().OnWindowShow += windowType =>
            {
                if (windowType == WindowType.LeaderBoard)
                {
                    Show();
                    Social.ShowLeaderboardUI();
                }
            };
            
            _userInterfaceCycle.GetHeldItem().OnWindowHide += windowType =>
            {
                if (windowType == WindowType.LeaderBoard)
                {
                    Hide();
                }
            };
            
            _closeButton.onClick.AddListener(() =>
            {
                _userInterfaceCycle.GetHeldItem().HideWindow(WindowType.LeaderBoard);
                _userInterfaceCycle.GetHeldItem().ShowWindow(WindowType.GameOver);
            });
        }
    }
}