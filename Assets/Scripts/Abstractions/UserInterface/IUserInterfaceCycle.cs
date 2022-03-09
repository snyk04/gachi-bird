using System;

namespace GachiBird.UserInterface
{
    public interface IUserInterfaceCycle
    {
        event Action? OnLeaderBoardShow;
        event Action? OnLeaderBoardHide;

        event Action? OnGameOverWindowShow;
        event Action? OnGameOverWindowHide;

        void ShowLeaderBoard();
        void HideLeaderBoard();

        void ShowGameOverWindow();
        void HideGameOverWindow();
    }
}