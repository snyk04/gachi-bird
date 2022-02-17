using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Environment;
using GachiBird.Environment.Pooling;
using UnityEngine;

namespace GachiBird.Flex
{
    public sealed class ColliderCollectorComponent : DestroyableAbstractComponent<ColliderCollector>
    {
#nullable disable
        [Header("References")]
        [SerializeField] private AbstractComponent<IFlexModeHandler> _flexModeHandler;
        [SerializeField] private AbstractComponent<IPool<GameObject>> _boosterPool;
        [SerializeField] private AbstractComponent<IPool<GameObject>> _obstaclePool;
        
        [Header("Settings")]
        [SerializeField] private float _timeGapBeforeObstaclesAreSolidAgain;
#nullable enable

        protected override ColliderCollector Create()
        {
            return new ColliderCollector(_flexModeHandler.HeldItem, _boosterPool.HeldItem, _obstaclePool.HeldItem,
                _timeGapBeforeObstaclesAreSolidAgain);
        }
    }
}