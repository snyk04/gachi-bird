using System;
using GachiBird.Game;
using GachiBird.Serialization;

namespace GachiBird.UserInterface
{
    // TODO : Use Dictionary<enum, Action> and pair of methods, instead of bunch of actions and methods
    
    public class UserInterfaceCycle : IUserInterfaceCycle
    {
        private readonly IGameCycle _gameCycle;
        private readonly IGameSaver _gameSaver;

        public event Action? OnGameOverWindowShow;
        public event Action? OnPreStartWindowShow;
        public event Action? OnScoreWindowShow;
        public event Action? OnShopWindowShow;
        public event Action? OnMusicListWindowShow;
        public event Action? OnLeaderBoardWindowShow;
        
        public event Action? OnGameOverWindowHide;
        public event Action? OnPreStartWindowHide;
        public event Action? OnScoreWindowHide;
        public event Action? OnShopWindowHide;
        public event Action? OnMusicListWindowHide;
        public event Action? OnLeaderBoardWindowHide;

        public UserInterfaceCycle(IGameCycle gameCycle, IGameSaver gameSaver)
        {
            _gameCycle = gameCycle;
            _gameSaver = gameSaver;
            
            _gameCycle.OnGameStart += ShowScoreWindow;
            _gameCycle.OnGameStart += HidePreStartWindow;
            _gameCycle.OnGameEnd += ShowGameOverWindow;
            _gameCycle.OnGameEnd += HideScoreWindow;
        }

        public void Start()
        {
            ShowPreStartWindow();
        }
        
        public void ShowGameOverWindow()
        {
            OnGameOverWindowShow?.Invoke();
        }
        public void ShowPreStartWindow()
        {
            OnPreStartWindowShow?.Invoke();
        }
        public void ShowScoreWindow()
        {
            OnScoreWindowShow?.Invoke();
        }
        public void ShowShopWindow()
        {
            OnShopWindowShow?.Invoke();
        }
        public void ShowMusicListWindow()
        {
            OnMusicListWindowShow?.Invoke();
        }
        public void ShowLeaderBoardWindow()
        {
            OnLeaderBoardWindowShow?.Invoke();
        }

        public void HideGameOverWindow()
        {
            OnGameOverWindowHide?.Invoke();
        }
        public void HidePreStartWindow()
        {
            OnPreStartWindowHide?.Invoke();
        }
        public void HideScoreWindow()
        {
            OnScoreWindowHide?.Invoke();
        }
        public void HideShopWindow()
        {
            OnShopWindowHide?.Invoke();
        }
        public void HideMusicListWindow()
        {
            OnMusicListWindowHide?.Invoke();
        }
        public void HideLeaderBoardWindow()
        {
            OnLeaderBoardWindowHide?.Invoke();
        }
    }
}