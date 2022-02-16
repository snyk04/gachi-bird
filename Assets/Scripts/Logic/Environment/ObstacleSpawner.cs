using System;
using System.Threading;
using AreYouFruits.Common;
using GachiBird.Environment.Colliders;
using GachiBird.Environment.Objects;
using GachiBird.Environment.Pooling;
using GachiBird.Game;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GachiBird.Environment
{
    public sealed class ObstacleSpawner : IObstacleSpawner
    {
        private readonly IPool<GameObject> _pool;
        public float Gap { get; }
        private readonly Vector3 _playerOffset;
        private readonly Range<float> _heightRange;

        private Vector3 _startOffset;
        private int _spawnedCount = 0;

        public event Action? OnObstaclePassed;

        private readonly CancellationTokenSource _cancellationSource = new CancellationTokenSource();

        public ObstacleSpawner(
            IGameCycle gameCycle, IPool<GameObject> pool, float gap, Vector3 playerOffset, Range<float> heightRange, 
            Transform player
        )
        {
            gameCycle.OnGameStart += () => Start(player.position);
            _pool = pool;
            Gap = gap;
            _playerOffset = playerOffset;
            _heightRange = heightRange;
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
            if (_cancellationSource.Token.IsCancellationRequested)
            {
                return;
            }

            Vector3 dispersion = _heightRange.Random() * new Vector3(0, 1, 0);
                
            Vector3 position = _startOffset + _spawnedCount * Gap * Vector3.right + dispersion;
            GameObject createdObject = _pool.Get();
            createdObject.transform.position = position;

            IObstacle obstacle = createdObject.GetComponent<IObstacle>();
            obstacle.CheckpointCollider2DListener.OnTrigger += HandleObstacleTriggered;

            _spawnedCount++;
        }

        public void Stop() => _cancellationSource.Cancel();
    }
}
