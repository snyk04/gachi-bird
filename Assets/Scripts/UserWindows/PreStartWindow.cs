#nullable enable

using GachiBird.Game;
using UnityEngine;

namespace GachiBird.UserWindows
{
    public sealed class PreStartWindow : BaseWindow
    {
#nullable disable
        [SerializeField] private GameCycleComponent _gameCycle;
#nullable enable
        
        private void Awake()
        {
            Show();
            _gameCycle.HeldItem.OnGameStart += Hide;
        }
    }
}
