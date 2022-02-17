using AreYouFruits.Common.ComponentGeneration;
using GachiBird.PlayerLogic;
using UnityEngine;

namespace GachiBird.Flex
{
    public sealed class FlexMoverComponent : AbstractComponent<FlexMover>
    {
#nullable disable
        [SerializeField] private SerializedInterface<IComponent<IFlexModeHandler>> _flexModeHandler;
        [SerializeField] private SerializedInterface<IComponent<IMovable>> _player;
#nullable enable
        
        protected override FlexMover Create()
        {
            return new FlexMover(_flexModeHandler.GetHeldItem(), _player.GetHeldItem());
        }
    }
}