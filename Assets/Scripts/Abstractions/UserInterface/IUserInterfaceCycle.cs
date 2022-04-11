using System;

namespace GachiBird.UserInterface
{
    public interface IUserInterfaceCycle
    {
        event Action? OnGameOverWindowShow;
        event Action? OnPreStartWindowShow;
        event Action? OnScoreWindowShow;

        event Action? OnGameOverWindowHide;
        event Action? OnPreStartWindowHide;
        event Action? OnScoreWindowHide;

        
        void ShowGameOverWindow();
        void ShowPreStartWindow();
        void ShowScoreWindow();
        
        void HideGameOverWindow();
        void HidePreStartWindow();
        void HideScoreWindow();
    }
}