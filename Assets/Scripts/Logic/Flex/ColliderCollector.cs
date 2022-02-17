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
        private readonly List<Collider2D> _colliders;

        private bool _areCollidersActive = true;
        
        private readonly CancellationTokenSource _cancellationSource = new CancellationTokenSource();

        public ColliderCollector(
            IFlexModeHandler flexModeHandler, IPool<GameObject> boosterPool, IPool<GameObject> obstaclePool,
            float timeGapBeforeObstaclesAreSolidAgain
        )
        {
            _colliders = new List<Collider2D>();

            boosterPool.OnCreate += HandleBoosterCreated;
            obstaclePool.OnCreate += HandleObstacleCreated;

            flexModeHandler.OnFlexModeStart += _ => SetCollidersActive(false);
            flexModeHandler.OnFlexModeEnd += HandleFlexModeEnd;
            
            async void HandleFlexModeEnd()
            {
                await Tasks.DelaySeconds(timeGapBeforeObstaclesAreSolidAgain);
                if (!_cancellationSource.IsCancellationRequested)
                {
                    SetCollidersActive(true);
                }
            }
        }

        private void HandleBoosterCreated(GameObject booster)
        {
            _colliders.AddRange(booster.GetHeldItem<IBooster>().BoosterPickedUpCollider2DListener.Colliders);
        }
        private void HandleObstacleCreated(GameObject obstacleObject)
        {
            IObstacle obstacle = obstacleObject.GetComponent<IObstacle>();
            Collider2D[] obstacleColliders = obstacle.ObstacleCollider2DListener.Colliders;
            _colliders.AddRange(obstacleColliders);

            foreach (Collider2D collider in obstacleColliders)
            {
                collider.enabled = _areCollidersActive;
            }
        }

        private void SetCollidersActive(bool isActive)
        {
            _areCollidersActive = isActive;
            _colliders.ForEach(collider => collider.enabled = isActive);
        }
        
        public void Dispose()
        {
            _cancellationSource.Cancel();
        }
    }
}
