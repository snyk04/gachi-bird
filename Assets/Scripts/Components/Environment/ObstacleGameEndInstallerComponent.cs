using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Environment.Pooling;
using GachiBird.Game;
using UnityEngine;

namespace GachiBird.Environment
{
    public sealed class ObstacleGameEndInstallerComponent : AbstractComponent<ObstacleGameEndInstaller>
    {
#nullable disable
        [SerializeField] private SerializedInterface<IComponent<IGameCycle>> _gameCycle;
        [SerializeField] private SerializedInterface<IComponent<IPool<GameObject>>> _pool;
#nullable enable
        
        protected override ObstacleGameEndInstaller Create()
        {
            return new ObstacleGameEndInstaller(_gameCycle.GetHeldItem(), _pool.GetHeldItem());
        }
    }
}
