using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Environment.Objects;
using GachiBird.Environment.Pooling;
using GachiBird.Game;
using UnityEngine;

namespace GachiBird.Environment
{
    public sealed class GameEndInstaller
    {
        public GameEndInstaller(IGameCycle gameCycle, IPool<GameObject> bordersPool, IPool<GameObject> obstaclePool)
        {
            bordersPool.OnCreate += HandleBordersCreated;
            obstaclePool.OnCreate += HandleObstacleCreated;

            void HandleBordersCreated(GameObject item)
            {
                var borders = item.GetHeldItem<IBorders>();
                borders.CeilingCollider2DListener.OnCollide += (_, __) => gameCycle.EndGame();
                borders.FloorCollider2DListener.OnCollide += (_, __) => gameCycle.EndGame();
            }
            void HandleObstacleCreated(GameObject item)
            {
                var obstacle = item.GetComponent<IObstacle>();
                obstacle.ObstacleCollider2DListener.OnCollide += (_, __) => gameCycle.EndGame();
            }
        }
    }
}