using AreYouFruits.Common.ComponentGeneration;
using GachiBird.PlayerLogic;
using UnityEngine;

namespace GachiBird.Flex
{
    public sealed class FlexMoverComponent : AbstractComponent<FlexMover>
    {
#nullable disable
        [SerializeField] private AbstractComponent<IFlexModeHandler> _flexModeHandler;
        [SerializeField] private AbstractComponent<IMovable> _player;
#nullable enable
        
        protected override FlexMover Create()
        {
            return new FlexMover(_flexModeHandler.HeldItem, _player.HeldItem);
        }
    }
}