using UnityEngine;

namespace AreYouFruits.Common.UnityWithInterfaces
{
    internal interface IVelocity2DChanger : IVelocity2DGetter, IVelocity2DSetter { }

    internal interface IVelocity2DGetter { Vector2 Velocity { get; } }
    internal interface IVelocity2DSetter { Vector2 Velocity { set; } }
    
    internal interface IRigidbody2D : IVelocity2DChanger, IKinematicChanger { }
    
    internal readonly struct Rigidbody2DHolder : IRigidbody2D
    {
        private readonly Rigidbody2D _rigidbody;

        public Rigidbody2DHolder(Rigidbody2D rigidbody) => _rigidbody = rigidbody;

        public Vector2 Velocity { get => _rigidbody.velocity; set => _rigidbody.velocity = value; }
        public bool IsKinematic { get => _rigidbody.isKinematic; set => _rigidbody.isKinematic = value; }
    }
}
