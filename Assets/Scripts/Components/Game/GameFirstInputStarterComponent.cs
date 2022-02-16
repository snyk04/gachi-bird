using AreYouFruits.Common.ComponentGeneration;
using UnityEngine;

namespace GachiBird.Game
{
    public sealed class GameFirstInputStarterComponent : AbstractComponent<GameFirstInputStarter>
    {
#nullable disable
        [SerializeField] private AbstractComponent<IGameCycle> _gameCycle;
#nullable enable
        
        protected override GameFirstInputStarter Create() => new GameFirstInputStarter(_gameCycle.HeldItem);
    }
}
