using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Game;
using UnityEngine;

namespace GachiBird.PlayerLogic
{
    public sealed class JumperComponent : AbstractComponent<IJumpable>
    {
#nullable disable
        [SerializeField] private AbstractComponent<IGameCycle> _gameCycle;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _jumpForce;
#nullable enable

        protected override IJumpable Create() => new Jumper(_gameCycle.HeldItem, _rigidbody, _jumpForce);
        }
}

