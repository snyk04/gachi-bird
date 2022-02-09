#nullable enable

using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Game;
using UnityEngine;

namespace GachiBird.PlayerLogic
{
    public sealed class PlayerComponent : AbstractComponent<IPlayer>
    {
#nullable disable
        [SerializeField] private AbstractComponent<IGameCycle> _gameCycle;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _speed;
#nullable enable
        
        protected override IPlayer Create() => new Player(_gameCycle.HeldItem, _rigidbody, _jumpForce, _speed);
    }
}

