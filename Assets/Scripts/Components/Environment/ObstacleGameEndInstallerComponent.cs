using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Environment.Pooling;
using GachiBird.Game;
using UnityEngine;

namespace GachiBird.Environment
{
    public sealed class ObstacleGameEndInstallerComponent : AbstractComponent<ObstacleGameEndInstaller>
    {
#nullable disable
        [SerializeField] private AbstractComponent<IGameCycle> _gameCycle;
        [SerializeField] private AbstractComponent<IPool<GameObject>> _pool;
#nullable enable
        
        protected override ObstacleGameEndInstaller Create()
        {
            return new ObstacleGameEndInstaller(_gameCycle.HeldItem, _pool.HeldItem);
        }
    }
}
