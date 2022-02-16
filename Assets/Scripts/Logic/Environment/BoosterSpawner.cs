#nullable enable

using System;
using System.Threading;
using AreYouFruits.Common;
using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Environment.Colliders;
using GachiBird.Environment.Objects;
using GachiBird.Environment.Pooling;
using GachiBird.Game;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GachiBird.Environment
{
    public sealed class BoosterSpawner : IBoosterSpawner
    {
        private readonly IPool<GameObject> _pool;
        private readonly IObstacleSpawner _obstacleSpawner;
        private readonly BoosterInfo[] _boosterSettingsArray;
        private readonly Range<int> _gapRange;
        private readonly Vector3 _playerOffset;
        private readonly Range<float> _widthRange;
        private readonly Range<float> _heightRange;

        private Vector3 _startOffset;
        private int _spawnedCount = 0;

        public event Action? OnBoosterCollected;

        private readonly CancellationTokenSource _cancellationSource = new CancellationTokenSource();

        public BoosterSpawner(
            IGameCycle gameCycle, IPool<GameObject> pool, IObstacleSpawner obstacleSpawner,
            BoosterInfo[] boosterSettingsArray, Range<int> gapRange, Vector3 playerOffset,
            Range<float> widthRange, Range<float> heightRange, Transform player
        )
        {
            gameCycle.OnGameStart += () => Start(player.position);
            _pool = pool;
            _obstacleSpawner = obstacleSpawner;
            _boosterSettingsArray = boosterSettingsArray;
            _gapRange = gapRange;
            _playerOffset = playerOffset;
            _widthRange = widthRange;
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
            OnBoosterCollected?.Invoke();
        }

        private void TrySpawn()
        {
            if (_cancellationSource.Token.IsCancellationRequested)
            {
                return;
            }

            var dispersion = new Vector3(_widthRange.Random(), _widthRange.Random(), 0.0f);
            
            Vector3 position = _startOffset 
              + (_spawnedCount + 1) * _obstacleSpawner.Gap * _gapRange.Random() * Vector3.right
              + dispersion;
            
            GameObject createdObject = _pool.Get();
            createdObject.transform.position = position;

            IBooster booster = createdObject.GetHeldItem<IBooster>();
            booster.CheckpointCollider2DListener.OnTrigger += HandleObstacleTriggered;
            booster.Initialize(_boosterSettingsArray[Random.Range(0, _boosterSettingsArray.Length)]);

            _spawnedCount++;
        }

        public void Stop() => _cancellationSource.Cancel();
    }
}
