using AreYouFruits.Common.ComponentGeneration;
using UnityEngine;

namespace GachiBird.PlayerLogic
{
    public sealed class MoverComponent : AbstractComponent<IMovable>
    {
#nullable disable
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _speed;
#nullable enable
        
        protected override IMovable Create() => new Mover(_rigidbody, _speed);
    }
}