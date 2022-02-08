#nullable enable

using System;
using System.Threading;
using GachiBird.Environment.Objects;
using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Environment.Colliders;
using GachiBird.Environment.Pooling;
using GachiBird.Game;
using UnityEngine;

namespace GachiBird.Environment
{
    public sealed class ObstacleSpawnerComponent : AbstractComponent<ObstacleSpawner>
    {
#nullable disable
        [Header("References")]
        [SerializeField] private GameCycle _gameCycle;
        [SerializeField] private GameObjectPoolComponent _gameObjectPool;
        [SerializeField] private float _gap;
        [SerializeField] private Vector3 _playerOffset;
        [SerializeField] private Transform _player;
#nullable enable

        protected override ObstacleSpawner Create()
        {
            return new ObstacleSpawner(_gameCycle, _gameObjectPool.HeldItem, _gap, _playerOffset, _player);
        }
    }

    public class ObstacleSpawner
    {
        private readonly IPool<GameObject> _pool;
        private readonly float _gap;
        private readonly Vector3 _playerOffset;

        private Vector3 _startOffset;
        private ushort _spawnedCount = 0;

        public event Action OnObstaclePassed; 

        private readonly CancellationTokenSource _cancellationSource = new CancellationTokenSource();

        public ObstacleSpawner(GameCycle gameCycle, IPool<GameObject> pool, float gap, Vector3 playerOffset, Transform player)
        {
            gameCycle.OnGameStart += () => Start(player.position);
            _pool = pool;
            _gap = gap;
            _playerOffset = playerOffset;
        }

        private void Start(Vector3 startOffset)
        {
            _startOffset = startOffset + _playerOffset;

            TrySpawn();
        }

        private void HandleObstacleTriggered(Collider2D collider, Collider2DListener collider2DListener)
        {
            collider2DListener.OnTrigger -= HandleObstacleTriggered;

            TrySpawn();
            OnObstaclePassed?.Invoke();
        }

        private void TrySpawn()
        {
            if (!_cancellationSource.Token.IsCancellationRequested)
            {
                Vector3 position = _startOffset + _spawnedCount * _gap * Vector3.right;
                GameObject createdObject = _pool.Get();
                createdObject.transform.position = position;

                ObstacleComponent obstacle = createdObject.GetComponent<ObstacleComponent>();
                obstacle.CheckpointCollider2DListener.OnTrigger += HandleObstacleTriggered;

                _spawnedCount++;
            }
        }

        public void Stop() => _cancellationSource.Cancel();
    }
}
