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
        [SerializeField] private SerializedInterface<IComponent<IFlexModeHandler>> _flexModeHandler;
        [SerializeField] private SerializedInterface<IComponent<IPool<GameObject>>> _boosterPool;
        [SerializeField] private SerializedInterface<IComponent<IPool<GameObject>>> _obstaclePool;
        
        [Header("Settings")]
        [SerializeField] private float _timeGapBeforeObstaclesAreSolidAgain;
#nullable enable

        protected override ColliderCollector Create()
        {
            return new ColliderCollector(_flexModeHandler.GetHeldItem(), _boosterPool.GetHeldItem(), _obstaclePool.GetHeldItem(),
                _timeGapBeforeObstaclesAreSolidAgain);
        }
    }
}