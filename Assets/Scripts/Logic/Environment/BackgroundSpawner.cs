using System.Threading;
using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Environment.Colliders;
using GachiBird.Environment.Objects;
using GachiBird.Environment.Pooling;
using UnityEngine;

namespace GachiBird.Environment
{
    public sealed class BackgroundSpawner
    {
        private readonly IPool<GameObject> _pool;
        private readonly float _gap;
        private readonly Vector3 _playerOffset;

        private Vector3 _startOffset;
        private int _spawnedCount = 0;
        
        private readonly CancellationTokenSource _cancellationSource = new CancellationTokenSource();

        public BackgroundSpawner(IPool<GameObject> pool, float gap, Vector3 playerOffset,
            Transform player)
        {
            _pool = pool;
            _gap = gap;
            _playerOffset = playerOffset;
            
            pool.OnInitialize += () => Start(player.position);
        }

        private void Start(Vector3 startOffset)
        {
            _startOffset = startOffset + _playerOffset;

            TrySpawn();
        }

        private void HandleBackgroundPassed(Collider2D collider, ICollider2DListener collider2DListener)
        {
            collider2DListener.OnTrigger -= HandleBackgroundPassed;

            TrySpawn();
        }

        private void TrySpawn()
        {
            if (_cancellationSource.Token.IsCancellationRequested)
            {
                return;
            }
            
            Vector3 position = _startOffset + _spawnedCount * _gap * Vector3.right;
            GameObject createdObject = _pool.Get();
            createdObject.transform.position = position;

            var background = createdObject.GetHeldItem<IBackground>();
            background.BackgroundPassCollider2DListener.OnTrigger += HandleBackgroundPassed;

            _spawnedCount++;
        }

        public void Stop() => _cancellationSource.Cancel();
    }
}