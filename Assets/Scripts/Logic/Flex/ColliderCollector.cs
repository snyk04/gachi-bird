using System.Collections.Generic;
using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Environment;
using GachiBird.Environment.Objects;
using GachiBird.Environment.Pooling;
using UnityEngine;

namespace GachiBird.Flex
{
    public class ColliderCollector
    {
        private readonly List<Collider2D> _colliders;
        
        // TODO : Use IPool<GameObject>
        public ColliderCollector(IFlexModeHandler flexModeHandler, 
            IBoosterSpawner boosterSpawner, IPool<GameObject> obstaclePool)
        {
            _colliders = new List<Collider2D>();
            
            boosterSpawner.OnBoosterSpawned += HandleBoosterCreated;
            obstaclePool.OnCreate += HandleObstacleCreated;
            
            flexModeHandler.OnFlexModeStart += _ => SetCollidersActive(false);
            flexModeHandler.OnFlexModeEnd += () => SetCollidersActive(true);
        }

        private void HandleBoosterCreated(IBooster booster)
        {
            Collider2D[] boosterColliders = booster.BoosterPickedUpCollider2DListener.Colliders;
            _colliders.AddRange(boosterColliders);
        }
        private void HandleObstacleCreated(GameObject obstacleObject)
        {
            IObstacle obstacle = obstacleObject.GetComponent<IObstacle>(); 
            Collider2D[] obstacleColliders = obstacle.ObstacleCollider2DListener.Colliders;
            _colliders.AddRange(obstacleColliders);
        }

        private void SetCollidersActive(bool isActive)
        {
            _colliders.ForEach(collider => collider.enabled = isActive);
        }
    }
}