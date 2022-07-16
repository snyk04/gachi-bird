using System;

namespace GachiBird.UserInterface
{
    public enum WindowType
    {
        GameOver = 0,
        PreStart = 1,
        Score = 2,
        Shop = 3,
        MusicList = 4,
        Info = 5
    }

    public interface IUserInterfaceCycle
    {
        public event Action<WindowType>? OnWindowShow;
        public event Action<WindowType>? OnWindowHide;

        public void ShowWindow(WindowType windowType);
        public void HideWindow(WindowType windowType);
    }

    public interface IWindow
    {
        void Show();
        void Hide();
    }

    public interface IWindowHandler
    {
        public event Action<IWindow>? OnWindowShow;
        public event Action<IWindow>? OnWindowHide;

        public void ShowWindow<TWindow>()
            where TWindow : IWindow;
        
        public void HideWindow<TWindow>()
            where TWindow : IWindow;
    }
}