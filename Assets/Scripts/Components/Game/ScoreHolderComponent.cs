using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Environment;
using GachiBird.Game;
using GachiBird.Serialization;
using UnityEngine;
using UnityEngine.Serialization;

namespace GachiBird.UserWindows
{
    public sealed class ScoreHolderComponent : AbstractComponent<ScoreHolder>
    {
#nullable disable
        [Header("References")]
        [SerializeField] private SerializedInterface<IComponent<IObstacleSpawner>> _obstacleSpawner;
        [SerializeField] private SerializedInterface<IComponent<IGameCycle>> _gameCycle;
        [FormerlySerializedAs("_serializationManager")] [SerializeField] private SerializedInterface<IComponent<IGameLoader>> _gameLoader;
        [SerializeField] private int _pointsPerCheckpoint;
#nullable enable
        
        protected override ScoreHolder Create()
        {
            return new ScoreHolder(
                _obstacleSpawner.GetHeldItem(),
                _gameCycle.GetHeldItem(),
                _gameLoader.GetHeldItem(),
                _pointsPerCheckpoint
            );
        }
    }
}
