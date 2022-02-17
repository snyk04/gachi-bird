using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Game;
using GachiBird.PlayerLogic;
using UnityEngine;

namespace GachiBird.Input
{
    public sealed class PlayerInputComponent : DestroyableAbstractComponent<PlayerInput>
    {
#nullable disable
        [SerializeField] private SerializedInterface<IComponent<IGameCycle>> _gameCycle;
        [SerializeField] private SerializedInterface<IComponent<IJumpable>> _player;
#nullable enable
        
        protected override PlayerInput Create() => new PlayerInput(_gameCycle.GetHeldItem(), _player.GetHeldItem());
    }
}
