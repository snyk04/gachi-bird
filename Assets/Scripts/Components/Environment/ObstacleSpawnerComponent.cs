using System;
using AreYouFruits.Common;
using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Environment.Pooling;
using GachiBird.Game;
using UnityEngine;

namespace GachiBird.Environment
{
    public sealed class ObstacleSpawnerComponent : AbstractComponent<ObstacleSpawner, IObstacleSpawner>
    {
#nullable disable
        [Header("References")]
        [SerializeField] private SerializedInterface<IComponent<IGameCycle>> _gameCycle;
        [SerializeField] private SerializedInterface<IComponent<IPool<GameObject>>> _gameObjectPool;
        [SerializeField] private float _gap;
        [SerializeField] private Vector3 _playerOffset;
        [SerializeField] private Range<float> _heightRange;
        [SerializeField] private Transform _player;
#nullable enable

        protected override ObstacleSpawner Create()
        {
            return new ObstacleSpawner(
                _gameCycle.GetHeldItem(),
                _gameObjectPool.GetHeldItem(),
                _gap,
                _playerOffset,
                _heightRange,
                _player
            );
        }

        private void OnDrawGizmosSelected()
        {
            if (!_heightRange.IsBounded)
            {
                return;
            }

            Gizmos.color = Color.yellow;
            Vector3 center = (_heightRange.Min + _heightRange.Max) / 2.0f * Vector3.up;
            const float depth = 10.0f;
            const float width = 100_000.0f;
            Gizmos.DrawWireCube(center, new Vector3(width, _heightRange.Max - _heightRange.Min, depth));
        }
    }
}
