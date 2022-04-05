using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Game;
using UnityEngine;

namespace GachiBird.Flex
{
    public sealed class FlexModeHandlerComponent : AbstractComponent<FlexModeHandler>
    {
#nullable disable
        [SerializeField] private SerializedInterface<IComponent<IGameCycle>> _gameCycle;
#nullable enable
        
        protected override FlexModeHandler Create()
        {
            return new FlexModeHandler(_gameCycle.GetHeldItem());
        }
    }
}