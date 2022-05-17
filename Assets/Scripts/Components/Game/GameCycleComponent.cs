using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Environment.Colliders;
using GachiBird.PlayerLogic;
using UnityEngine;

namespace GachiBird.Game
{
    public sealed class GameCycleComponent : AbstractComponent<GameCycle>
    {
#nullable disable
        [SerializeField] private int _gameSceneId;
#nullable enable
        
        protected override GameCycle Create() => new GameCycle(_gameSceneId);
    }
}