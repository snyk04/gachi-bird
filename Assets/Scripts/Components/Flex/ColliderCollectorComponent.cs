using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Environment;
using GachiBird.Environment.Pooling;
using UnityEngine;

namespace GachiBird.Flex
{
    public sealed class ColliderCollectorComponent : AbstractComponent<ColliderCollector>
    {
#nullable disable
        [SerializeField] private AbstractComponent<IFlexModeHandler> _flexModeHandler;
        [SerializeField] private AbstractComponent<IBoosterSpawner> _boosterSpawner;
        [SerializeField] private AbstractComponent<IPool<GameObject>> _obstaclePool;
#nullable enable

        protected override ColliderCollector Create()
        {
            return new ColliderCollector(_flexModeHandler.HeldItem, _boosterSpawner.HeldItem, _obstaclePool.HeldItem);
        }
    }
}