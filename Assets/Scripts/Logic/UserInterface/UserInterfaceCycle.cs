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

        public event Action? OnLeaderBoardShow;
        public event Action? OnGameOverWindowShow;
        public event Action? OnSetUserNameWindowShow;
        public event Action? OnPreStartWindowShow;
        public event Action? OnScoreWindowShow;
        
        public event Action? OnLeaderBoardHide;
        public event Action? OnGameOverWindowHide;
        public event Action? OnSetUserNameWindowHide;
        public event Action? OnPreStartWindowHide;
        public event Action? OnScoreWindowHide;
        
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
            if (_gameSaver.LoadUserName() == "")
            {
                ShowSetUserNameWindow();
            }
            else
            {
                ShowPreStartWindow();
            }
        }

        public void ShowLeaderBoard()
        {
            OnLeaderBoardShow?.Invoke();
        }
        public void ShowGameOverWindow()
        {
            OnGameOverWindowShow?.Invoke();
        }
        public void ShowSetUserNameWindow()
        {
            OnSetUserNameWindowShow?.Invoke();
        }
        public void ShowPreStartWindow()
        {
            OnPreStartWindowShow?.Invoke();
        }
        public void ShowScoreWindow()
        {
            OnScoreWindowShow?.Invoke();
        }
        
        public void HideLeaderBoard()
        {
            OnLeaderBoardHide?.Invoke();
        }
        public void HideGameOverWindow()
        {
            OnGameOverWindowHide?.Invoke();
        }
        public void HideSetUserNameWindow()
        {
            OnSetUserNameWindowHide?.Invoke();
        }
        public void HidePreStartWindow()
        {
            OnPreStartWindowHide?.Invoke();
        }
        public void HideScoreWindow()
        {
            OnScoreWindowHide?.Invoke();
        }
    }
}