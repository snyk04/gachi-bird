#nullable enable

using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Game;
using UnityEngine;

namespace GachiBird.UserWindows
{
    public sealed class PreStartWindow : BaseWindow
    {
#nullable disable
        [SerializeField] private AbstractComponent<IGameCycle> _gameCycle;
#nullable enable
        
        private void Awake()
        {
            Show();
            _gameCycle.HeldItem.OnGameStart += Hide;
        }
    }
}
