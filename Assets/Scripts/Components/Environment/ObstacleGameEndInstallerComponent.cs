using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Environment.Pooling;
using GachiBird.Game;
using UnityEngine;

namespace GachiBird.Environment
{
    public sealed class ObstacleGameEndInstallerComponent : AbstractComponent<GameEndInstaller>
    {
#nullable disable
        [SerializeField] private SerializedInterface<IComponent<IGameCycle>> _gameCycle;
        [SerializeField] private SerializedInterface<IComponent<IPool<GameObject>>> _bordersPool;
        [SerializeField] private SerializedInterface<IComponent<IPool<GameObject>>> _obstaclePool;
#nullable enable
        
        protected override GameEndInstaller Create()
        {
            return new GameEndInstaller(_gameCycle.GetHeldItem(), _bordersPool.GetHeldItem(), _obstaclePool.GetHeldItem());
        }
    }
}