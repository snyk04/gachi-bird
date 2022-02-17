using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Game;
using UnityEngine;

namespace GachiBird.PlayerLogic
{
    public sealed class PlayerFallerComponent : DestroyableAbstractComponent<PlayerFaller>
    {
#nullable disable
        [SerializeField] private SerializedInterface<IComponent<IGameCycle>> _gameCycle;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Collider2D _collider;
        [SerializeField] private Transform _transform;
        [SerializeField] private SerializedInterface<IComponent<IPlayerBordersTrigger>> _playerBorders;
#nullable enable

        protected override PlayerFaller Create() => new PlayerFaller(
            _gameCycle.GetHeldItem(),
            _rigidbody,
            _collider,
            _transform,
            _playerBorders.GetHeldItem()
        );
    }
}
