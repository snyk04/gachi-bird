using System;

namespace GachiBird.UserInterface
{
    public interface IUserInterfaceCycle
    {
        event Action? OnLeaderBoardShow;
        event Action? OnGameOverWindowShow;
        event Action? OnSetUserNameWindowShow;
        event Action? OnPreStartWindowShow;
        event Action? OnScoreWindowShow;

        event Action? OnLeaderBoardHide;
        event Action? OnGameOverWindowHide;
        event Action? OnSetUserNameWindowHide;
        event Action? OnPreStartWindowHide;
        event Action? OnScoreWindowHide;

        
        void ShowLeaderBoard();
        void ShowGameOverWindow();
        void ShowSetUserNameWindow();
        void ShowPreStartWindow();
        void ShowScoreWindow();
        
        void HideLeaderBoard();
        void HideGameOverWindow();
        void HideSetUserNameWindow();
        void HidePreStartWindow();
        void HideScoreWindow();
    }
}