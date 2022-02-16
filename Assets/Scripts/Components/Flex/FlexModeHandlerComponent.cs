using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Game;
using UnityEngine;

namespace GachiBird.Flex
{
    public sealed class FlexModeHandlerComponent : DestroyableAbstractComponent<IFlexModeHandler, FlexModeHandler>
    {
#nullable disable
        [SerializeField] private AbstractComponent<IGameCycle> _gameCycle;
#nullable enable
        
        protected override IFlexModeHandler Create()
        {
            return new FlexModeHandler(_gameCycle.HeldItem);
        }
    }
}