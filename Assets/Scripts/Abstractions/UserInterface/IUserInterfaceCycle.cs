using System;

namespace GachiBird.UserInterface
{
    public interface IUserInterfaceCycle
    {
        event Action? OnGameOverWindowShow;
        event Action? OnPreStartWindowShow;
        event Action? OnScoreWindowShow;
        event Action? OnShopWindowShow;
        event Action? OnMusicListWindowShow;

        event Action? OnGameOverWindowHide;
        event Action? OnPreStartWindowHide;
        event Action? OnScoreWindowHide;
        event Action? OnShopWindowHide;
        event Action? OnMusicListWindowHide;

        void ShowGameOverWindow();
        void ShowPreStartWindow();
        void ShowScoreWindow();
        void ShowShopWindow();
        void ShowMusicListWindow();
        
        void HideGameOverWindow();
        void HidePreStartWindow();
        void HideScoreWindow();
        void HideShopWindow();
        void HideMusicListWindow();
    }
}