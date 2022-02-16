using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Environment.Colliders;
using GachiBird.PlayerLogic;
using UnityEngine;

namespace GachiBird.Game
{
    public sealed class GameCycleComponent : AbstractComponent<IGameCycle>
    {
        protected override IGameCycle Create() => new GameCycle();
    }
}
