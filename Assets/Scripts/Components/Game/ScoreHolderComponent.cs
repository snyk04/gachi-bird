using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Environment;
using GachiBird.Game;
using GachiBird.Serialization;
using UnityEngine;

namespace GachiBird.UserWindows
{
    public sealed class ScoreHolderComponent : AbstractComponent<ScoreHolder>
    {
#nullable disable
        [Header("References")]
        [SerializeField] private SerializedInterface<IComponent<IGameSaver>> _serializationManager;
        [SerializeField] private SerializedInterface<IComponent<IObstacleSpawner>> _obstacleSpawner;
        [SerializeField] private int _pointsPerCheckpoint;
#nullable enable
        
        protected override ScoreHolder Create()
        {
            return new ScoreHolder(
                _obstacleSpawner.GetHeldItem(),
                _serializationManager.GetHeldItem().LoadBestScore(),
                _pointsPerCheckpoint
            );
        }
    }
}
