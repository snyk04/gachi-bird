#nullable enable

using System;
using System.Threading;
using GachiBird.Environment.Colliders;
using GachiBird.Environment.Objects;
using GachiBird.Environment.Pooling;
using GachiBird.Game;
using UnityEngine;

namespace GachiBird.Environment
{
    public sealed class ObstacleSpawner : IObstacleSpawner
    {
        private readonly IPool<GameObject> _pool;
        private readonly float _gap;
        private readonly Vector3 _playerOffset;

        private Vector3 _startOffset;
        private int _spawnedCount = 0;

        public event Action? OnObstaclePassed;

        private readonly CancellationTokenSource _cancellationSource = new CancellationTokenSource();

        public ObstacleSpawner(
            IGameCycle gameCycle, IPool<GameObject> pool, float gap, Vector3 playerOffset, Transform player
        )
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

        private void HandleObstacleTriggered(Collider2D collider, ICollider2DListener collider2DListener)
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

                IObstacle obstacle = createdObject.GetComponent<IObstacle>();
                obstacle.CheckpointCollider2DListener.OnTrigger += HandleObstacleTriggered;

                _spawnedCount++;
            }
        }

        public void Stop() => _cancellationSource.Cancel();
    }
}
