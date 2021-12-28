using GachiBird.Game;
using UnityEngine;

namespace GachiBird.UserInterface
{
    public sealed class PreStartInterface : GameInterface
    {
        [SerializeField] private GameCycle _gameCycle;
        
        private void Awake()
        {
            _gameCycle.OnGameStart += Hide;
        }
    }
}
