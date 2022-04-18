using System;

namespace GachiBird.UserInterface
{
    public interface IUserInterfaceCycle
    {
        event Action? OnGameOverWindowShow;
        event Action? OnPreStartWindowShow;
        event Action? OnScoreWindowShow;
        event Action? OnShopWindowShow;

        event Action? OnGameOverWindowHide;
        event Action? OnPreStartWindowHide;
        event Action? OnScoreWindowHide;
        event Action? OnShopWindowHide;
        
        void ShowGameOverWindow();
        void ShowPreStartWindow();
        void ShowScoreWindow();
        void ShowShopWindow();
        
        void HideGameOverWindow();
        void HidePreStartWindow();
        void HideScoreWindow();
        void HideShopWindow();
    }
}