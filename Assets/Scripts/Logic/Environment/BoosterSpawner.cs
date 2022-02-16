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

        public event Action<IBooster>? OnBoosterSpawned;

        private readonly CancellationTokenSource _cancellationSource = new CancellationTokenSource();

        public BoosterSpawner(
            IGameCycle gameCycle, IPool<GameObject> pool, IObstacleSpawner obstacleSpawner, 
            BoosterInfo[] boosterSettingsArray, Range<int> gapRange, Vector3 playerOffset, Range<float> widthRange,
            Range<float> heightRange, Transform player
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

        private void HandleBoosterPassed(Collider2D collider, ICollider2DListener collider2DListener)
        {
            collider2DListener.OnTrigger -= HandleBoosterPassed;

            TrySpawn();
        }
        private void HandleBoosterPickedUp(GameObject boosterObject, IBooster booster, BoosterInfo boosterInfo)
        {
            booster.PickedUp -= HandleBoosterPickedUp;
            
            _pool.Return(boosterObject);
        }

        private void TrySpawn()
        {
            if (_cancellationSource.Token.IsCancellationRequested)
            {
                return;
            }

            Vector3 widthDispersion = _widthRange.Random() * new Vector3(1, 0, 0);
            Vector3 heightDispersion = _heightRange.Random() * new Vector3(0, 1, 0);
                
            // TODO : Make first booster spawn not straight after first obstacle but using random
            Vector3 position = _startOffset + _spawnedCount * _obstacleSpawner.Gap * _gapRange.Random() * Vector3.right
                                            + widthDispersion + heightDispersion;
            GameObject createdObject = _pool.Get();
            createdObject.transform.position = position;

            IBooster booster = createdObject.GetHeldItem<IBooster>();
            booster.CheckpointCollider2DListener.OnTrigger += HandleBoosterPassed;
            booster.PickedUp += HandleBoosterPickedUp;
            OnBoosterSpawned?.Invoke(booster);
     
            BoosterInfo boosterInfo = _boosterSettingsArray[Random.Range(0, _boosterSettingsArray.Length)];
            booster.Initialize(boosterInfo);

            _spawnedCount++;
        }

        public void Stop() => _cancellationSource.Cancel();
    }
}