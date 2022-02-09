#nullable enable

using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Environment.Colliders;
using GachiBird.PlayerLogic;
using UnityEngine;

namespace GachiBird.Game
{
    public sealed class GameCycleComponent : AbstractComponent<IGameCycle>
    {
#nullable disable
        [SerializeField] private AbstractComponent<IPlayerBordersTrigger> _playerBordersTrigger;
        [SerializeField] private Collider2DListener _playerColliderListener;
#nullable enable
        
        protected override IGameCycle Create()
        {
            return new GameCycle(_playerBordersTrigger.HeldItem, _playerColliderListener);
        }
    }

    // todo: make StartGame and StopGame public (via dependencies)
}
