using System;

namespace GachiBird.UserInterface
{
    public interface IUserInterfaceCycle
    {
        event Action? OnLeaderBoardShow;
        event Action? OnGameOverWindowShow;
        event Action? OnPreStartWindowShow;
        event Action? OnScoreWindowShow;

        event Action? OnLeaderBoardHide;
        event Action? OnGameOverWindowHide;
        event Action? OnPreStartWindowHide;
        event Action? OnScoreWindowHide;

        
        void ShowLeaderBoard();
        void ShowGameOverWindow();
        void ShowPreStartWindow();
        void ShowScoreWindow();
        
        void HideLeaderBoard();
        void HideGameOverWindow();
        void HidePreStartWindow();
        void HideScoreWindow();
    }
}