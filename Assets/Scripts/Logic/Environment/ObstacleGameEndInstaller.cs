using GachiBird.Environment.Objects;
using GachiBird.Environment.Pooling;
using GachiBird.Game;
using UnityEngine;

namespace GachiBird.Environment
{
    public sealed class ObstacleGameEndInstaller
    {
        public ObstacleGameEndInstaller(IGameCycle gameCycle, IPool<GameObject> pool)
        {
            pool.OnCreate += HandleCreate;

            void HandleCreate(GameObject item)
            {
                IObstacle obstacle = item.GetComponent<IObstacle>();
                obstacle.ObstacleCollider2DListener.OnCollide += (_, __) => gameCycle.EndGame();
            }
        }
    }
}
