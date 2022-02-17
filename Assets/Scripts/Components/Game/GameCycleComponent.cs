using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Environment.Colliders;
using GachiBird.PlayerLogic;
using UnityEngine;

namespace GachiBird.Game
{
    public sealed class GameCycleComponent : AbstractComponent<GameCycle, IGameCycle>
    {
        protected override GameCycle Create() => new GameCycle();
    }
}
