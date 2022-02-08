using GachiBird.Game;
using UnityEngine;

namespace GachiBird.UserWindows
{
    public sealed class PreStartWindow : BaseWindow
    {
        [SerializeField] private GameCycle _gameCycle;
        
        private void Awake()
        {
            Show();
            _gameCycle.OnGameStart += Hide;
        }
    }
}
