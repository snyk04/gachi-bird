#nullable enable

using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Environment.Pooling;
using GachiBird.Game;
using UnityEngine;

namespace GachiBird.Environment
{
    public sealed class ObstacleSpawnerComponent : AbstractComponent<IObstacleSpawner>
    {
#nullable disable
        [Header("References")]
        [SerializeField] private AbstractComponent<IGameCycle> _gameCycle;
        [SerializeField] private AbstractComponent<IPool<GameObject>> _gameObjectPool;
        [SerializeField] private float _gap;
        [SerializeField] private Vector3 _playerOffset;
        [SerializeField] private Transform _player;
#nullable enable

        protected override IObstacleSpawner Create()
        {
            return new ObstacleSpawner(_gameCycle.HeldItem, _gameObjectPool.HeldItem, _gap, _playerOffset, _player);
        }
    }
}
