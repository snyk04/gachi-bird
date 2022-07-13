using System;
using System.Collections.Generic;
using System.Threading;
using AreYouFruits.Common;
using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Environment.Objects;
using GachiBird.Environment.Pooling;
using UnityEngine;

namespace GachiBird.Flex
{
    public class ColliderCollector : IDisposable
    {
        private readonly List<Collider2D> _boosterColliders;
        private readonly List<Collider2D> _obstacleColliders;
        private readonly float _timeGapBeforeObstaclesAreSolidAgain;
        
        private readonly CancellationTokenSource _cancellationSource = new CancellationTokenSource();

        private bool _isGameInFlexMode;

        public ColliderCollector(
            IFlexModeHandler flexModeHandler, IPool<GameObject> boosterPool, IPool<GameObject> obstaclePool,
            float timeGapBeforeObstaclesAreSolidAgain
        )
        {
            _boosterColliders = new List<Collider2D>();
            _obstacleColliders = new List<Collider2D>();
            _timeGapBeforeObstaclesAreSolidAgain = timeGapBeforeObstaclesAreSolidAgain;

            boosterPool.OnCreate += HandleBoosterCreated;
            obstaclePool.OnCreate += HandleObstacleCreated;

            flexModeHandler.OnFlexModeStart += _ => HandleFlexModeStart();
            flexModeHandler.OnFlexModeEnd += HandleFlexModeEnd;
        }

        private void HandleBoosterCreated(GameObject boosterObject)
        {
            var booster = boosterObject.GetHeldItem<IBooster>();
            Collider2D[] boosterColliders = booster.BoosterPickUpListener.Colliders;
            _boosterColliders.AddRange(boosterColliders);
        }
        private void HandleObstacleCreated(GameObject obstacleObject)
        {
            var obstacle = obstacleObject.GetComponent<IObstacle>();
            Collider2D[] obstacleColliders = obstacle.ObstacleCollider2DListener.Colliders;
            
            _obstacleColliders.AddRange(obstacleColliders);
        }

        private void HandleFlexModeStart()
        {
            _isGameInFlexMode = true;
            
            SetCollidersActive(false, _boosterColliders);
            SetCollidersActive(false, _obstacleColliders);
        }
        private async void HandleFlexModeEnd()
        {
            SetCollidersActive(true, _boosterColliders);
            _isGameInFlexMode = false;
            
            await Tasks.DelaySeconds(_timeGapBeforeObstaclesAreSolidAgain);
            
            if (!_cancellationSource.IsCancellationRequested)
            {
                if (!_isGameInFlexMode)
                {
                    SetCollidersActive(true, _obstacleColliders);
                }
            }
        }

        private void SetCollidersActive(bool isActive, List<Collider2D> colliders)
        {
            colliders.ForEach(collider => collider.enabled = isActive);
        }
        
        public void Dispose()
        {
            _cancellationSource.Cancel();
        }
    }
}
