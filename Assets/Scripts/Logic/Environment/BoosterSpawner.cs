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
        private readonly IGameCycle _gameCycle;
        private readonly IPool<GameObject> _pool;
        private readonly IObstacleSpawner _obstacleSpawner;
        private readonly BoosterInfo[] _boosterSettingsArray;
        private readonly Range<int> _gapRange;
        private readonly Vector3 _playerOffset;
        private readonly Range<float> _widthRange;
        private readonly Range<float> _heightRange;

        private Vector3 _startOffset;
        private int _lastGapCount = 0;

        public event Action<IBooster>? OnBoosterSpawned;

        private readonly CancellationTokenSource _cancellationSource = new CancellationTokenSource();

        public BoosterSpawner(
            IGameCycle gameCycle, IPool<GameObject> pool, IObstacleSpawner obstacleSpawner, 
            BoosterInfo[] boosterSettingsArray, Range<int> gapRange, Vector3 playerOffset, Range<float> widthRange,
            Range<float> heightRange, Transform player
        )
        {
            _gameCycle = gameCycle;
            _pool = pool;
            _obstacleSpawner = obstacleSpawner;
            _boosterSettingsArray = boosterSettingsArray;
            _gapRange = gapRange;
            _playerOffset = playerOffset;
            _widthRange = widthRange;
            _heightRange = heightRange;

            _gameCycle.OnGameStart += () => Start(player.position);
            _pool.OnCreate += HandleBoosterCreated;
        }
        
        private void HandleBoosterCreated(GameObject createdObject)
        {
            var booster = createdObject.GetHeldItem<IBooster>();
            booster.CheckpointCollider2DListener.OnTrigger += (_, __) => TrySpawn();
            booster.PickedUp += (boosterObject, _, __) => HandleBoosterPickedUp(boosterObject);
        }
        private void HandleBoosterPickedUp(GameObject boosterObject)
        {
            if (_gameCycle.IsPlaying)
            {
                _pool.Return(boosterObject);
            }
        }

        private void Start(Vector3 startOffset)
        {
            _startOffset = startOffset + _playerOffset;

            TrySpawn();
        }

        private void TrySpawn()
        {
            if (_cancellationSource.Token.IsCancellationRequested)
            {
                return;
            }
            
            var dispersion = new Vector3(_widthRange.Random(), _widthRange.Random(), 0.0f);

            _lastGapCount += _gapRange.RandomInt();
            
            Vector3 position = _startOffset 
              + _lastGapCount * _obstacleSpawner.Gap * Vector3.right
              + dispersion;
            
            GameObject createdObject = _pool.Get();
            createdObject.transform.position = position;

            IBooster booster = createdObject.GetHeldItem<IBooster>();
            OnBoosterSpawned?.Invoke(booster);
     
            BoosterInfo boosterInfo = _boosterSettingsArray[Random.Range(0, _boosterSettingsArray.Length)];
            booster.Initialize(boosterInfo);
        }

        public void Stop() => _cancellationSource.Cancel();
    }
}