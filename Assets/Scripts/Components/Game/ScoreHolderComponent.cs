#nullable enable

using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Environment;
using GachiBird.Game;
using GachiBird.Serialization;
using UnityEngine;

namespace GachiBird.UserWindows
{
    public sealed class ScoreHolderComponent : AbstractComponent<IScoreHolder>
    {
#nullable disable
        [Header("References")]
        [SerializeField] private AbstractComponent<IGameSaver> _serializationManager;
        [SerializeField] private AbstractComponent<IObstacleSpawner> _obstacleSpawner;
        [SerializeField] private int _pointsPerCheckpoint;
#nullable enable
        
        protected override IScoreHolder Create()
        {
            return new ScoreHolder(
                _obstacleSpawner.HeldItem,
                _serializationManager.HeldItem.LoadBestScore(),
                _pointsPerCheckpoint
            );
        }
    }
}
