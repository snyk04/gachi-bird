using System;

namespace GachiBird.UserInterface
{
    public class UserInterfaceCycle : IUserInterfaceCycle
    {
        public event Action? OnLeaderBoardShow;
        public event Action? OnLeaderBoardHide;
        
        public event Action? OnGameOverWindowShow;
        public event Action? OnGameOverWindowHide;

        public void ShowLeaderBoard()
        {
            OnLeaderBoardShow?.Invoke();
        }
        public void HideLeaderBoard()
        {
            OnLeaderBoardHide?.Invoke();
        }

        public void ShowGameOverWindow()
        {
            OnGameOverWindowShow?.Invoke();
        }
        public void HideGameOverWindow()
        {
            OnGameOverWindowHide?.Invoke();
        }
    }
}