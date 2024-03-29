﻿using System;
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
        private readonly Range<int> _gapRange;
        private readonly Vector3 _playerOffset;
        private readonly Range<float> _widthRange;
        private readonly Range<float> _heightRange;

        private Vector3 _startOffset;
        private int _lastGapCount;

        public event Action<IBooster>? OnBoosterSpawned;
        public BoosterInfo[] BoosterInfos { get; }

        private readonly CancellationTokenSource _cancellationSource = new CancellationTokenSource();

        public BoosterSpawner(
            IGameCycle gameCycle, IPool<GameObject> pool, IObstacleSpawner obstacleSpawner, 
            BoosterInfo[] boosterInfos, Range<int> gapRange, Vector3 playerOffset, Range<float> widthRange,
            Range<float> heightRange, Transform player
        )
        {
            _gameCycle = gameCycle;
            _pool = pool;
            _obstacleSpawner = obstacleSpawner;
            BoosterInfos = boosterInfos;
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
            booster.CheckpointListener.OnTrigger += (_, _) => HandleBoosterPassedBy(booster.CheckpointListener);
            booster.OnPickUp += (boosterObject, _, _) => HandleBoosterPickedUp(boosterObject);
        }
        private void HandleBoosterPickedUp(GameObject boosterObject)
        {
            if (_gameCycle.IsPlaying)
            {
                _pool.Return(boosterObject);
            }
        }
        private void HandleBoosterPassedBy(ICollider2DListener checkpointListener)
        {
            checkpointListener.SetActive(false);
            TrySpawn();
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

            var booster = createdObject.GetHeldItem<IBooster>();
            booster.CheckpointListener.SetActive(true);
            OnBoosterSpawned?.Invoke(booster);
     
            BoosterInfo boosterInfo = BoosterInfos[Random.Range(0, BoosterInfos.Length)];
            booster.Initialize(boosterInfo);
        }

        public void Stop() => _cancellationSource.Cancel();
    }
}