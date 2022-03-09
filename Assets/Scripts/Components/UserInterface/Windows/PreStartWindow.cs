using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Game;
using UnityEngine;

namespace GachiBird.UserInterface.Windows
{
    public sealed class PreStartWindow : BaseWindow
    {
#nullable disable
        [SerializeField] private SerializedInterface<IComponent<IGameCycle>> _gameCycle;
#nullable enable
        
        private void Awake()
        {
            Show();
            _gameCycle.GetHeldItem().OnGameStart += Hide;
        }
    }
}
