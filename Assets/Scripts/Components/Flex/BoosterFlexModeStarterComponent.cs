using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Environment;
using UnityEngine;

namespace GachiBird.Flex
{
    public sealed class BoosterFlexModeStarterComponent : AbstractComponent<BoosterFlexModeStarter>
    {
#nullable disable
        [SerializeField] private SerializedInterface<IComponent<IFlexModeHandler>> _flexModeHandler;
        [SerializeField] private SerializedInterface<IComponent<IBoosterSpawner>> _boosterSpawner;
#nullable enable

        protected override BoosterFlexModeStarter Create()
        {
            return new BoosterFlexModeStarter(_flexModeHandler.GetHeldItem(), _boosterSpawner.GetHeldItem());
        }
    }
}