#nullable enable

using System;
using System.Threading;
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
        private readonly float _gap;
        private readonly Vector3 _playerOffset;
        private readonly Borders _yDispersionBorders;

        private Vector3 _startOffset;
        private int _spawnedCount = 0;

        public event Action? OnObstaclePassed;

        private readonly CancellationTokenSource _cancellationSource = new CancellationTokenSource();

        public ObstacleSpawner(
            IGameCycle gameCycle, IPool<GameObject> pool, float gap, Vector3 playerOffset, Borders yDispersionBorders, 
            Transform player
        )
        {
            gameCycle.OnGameStart += () => Start(player.position);
            _pool = pool;
            _gap = gap;
            _playerOffset = playerOffset;
            _yDispersionBorders = yDispersionBorders;
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
                _yDispersionBorders.Deconstruct(out float leftBorder, out float rightBorder);
                Vector3 dispersion = Random.Range(leftBorder, rightBorder) * new Vector3(0, 1, 0);
                
                Vector3 position = _startOffset + _spawnedCount * _gap * Vector3.right + dispersion;
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
