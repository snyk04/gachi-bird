using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Game;
using UnityEngine;

namespace GachiBird.PlayerLogic
{
    public sealed class JumperComponent : AbstractComponent<Jumper>
    {
#nullable disable
        [SerializeField] private SerializedInterface<IComponent<IGameCycle>> _gameCycle;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _jumpForce;
#nullable enable

        protected override Jumper Create() => new Jumper(_gameCycle.GetHeldItem(), _rigidbody, _jumpForce);
    }
}
