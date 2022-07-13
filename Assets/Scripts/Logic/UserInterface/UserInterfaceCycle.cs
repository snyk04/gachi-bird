using System;
using GachiBird.Game;

namespace GachiBird.UserInterface
{
    public class UserInterfaceCycle : IUserInterfaceCycle
    {
        public event Action<WindowType>? OnWindowShow;
        public event Action<WindowType>? OnWindowHide;

        private readonly IGameCycle _gameCycle;

        public UserInterfaceCycle(IGameCycle gameCycle)
        {
            _gameCycle = gameCycle;

            _gameCycle.OnGameStart += () => ShowWindow(WindowType.Score);
            _gameCycle.OnGameStart += () => HideWindow(WindowType.PreStart);
            _gameCycle.OnGameEnd += () => ShowWindow(WindowType.GameOver);
            _gameCycle.OnGameEnd += () => HideWindow(WindowType.Score);
        }

        public void Start()
        {
            ShowWindow(WindowType.PreStart);
        }

        public void ShowWindow(WindowType windowType)
        {
            OnWindowShow?.Invoke(windowType);
        }

        public void HideWindow(WindowType windowType)
        {
            OnWindowHide?.Invoke(windowType);
        }
    }
}