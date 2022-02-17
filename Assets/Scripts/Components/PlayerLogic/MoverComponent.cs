using AreYouFruits.Common.ComponentGeneration;
using UnityEngine;

namespace GachiBird.PlayerLogic
{
    public sealed class MoverComponent : AbstractComponent<Mover, IMovable>
    {
#nullable disable
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _speed;
#nullable enable
        
        protected override Mover Create() => new Mover(_rigidbody, _speed);
    }
}