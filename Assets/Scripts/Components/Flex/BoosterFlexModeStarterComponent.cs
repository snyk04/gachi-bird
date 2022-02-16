using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Environment;
using UnityEngine;

namespace GachiBird.Flex
{
    public sealed class BoosterFlexModeStarterComponent : AbstractComponent<BoosterFlexModeStarter>
    {
#nullable disable
        [SerializeField] private AbstractComponent<IFlexModeHandler> _flexModeHandler;
        [SerializeField] private AbstractComponent<IBoosterSpawner> _boosterSpawner;
#nullable enable

        protected override BoosterFlexModeStarter Create()
        {
            return new BoosterFlexModeStarter(_flexModeHandler.HeldItem, _boosterSpawner.HeldItem);
        }
    }
}