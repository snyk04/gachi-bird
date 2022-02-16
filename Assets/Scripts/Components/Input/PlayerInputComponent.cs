using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Game;
using GachiBird.PlayerLogic;
using UnityEngine;

namespace GachiBird.Input
{
    public sealed class PlayerInputComponent : DestroyableAbstractComponent<PlayerInput>
    {
#nullable disable
        [SerializeField] private GameCycleComponent _gameCycle;
        [SerializeField] private AbstractComponent<IPlayer> _player;
#nullable enable
        
        protected override PlayerInput Create() => new PlayerInput(_gameCycle.HeldItem, _player.HeldItem);
    }
}
