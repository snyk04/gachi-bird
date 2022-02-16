using UnityEngine;

namespace AreYouFruits.Common.UnityWithInterfaces
{
    internal interface IVelocityChanger : IVelocityGetter, IVelocitySetter { }

    internal interface IVelocityGetter { Vector3 Velocity { get; } }
    internal interface IVelocitySetter { Vector3 Velocity { set; } }

    internal interface IKinematicChanger : IKinematicGetter, IKinematicSetter { }

    internal interface IKinematicGetter { bool IsKinematic { get; } }
    internal interface IKinematicSetter { bool IsKinematic { set; } }
    
    internal interface IRigidbody : IVelocityChanger, IKinematicChanger { }
    
    internal readonly struct RigidbodyHolder : IRigidbody
    {
        private readonly Rigidbody _rigidbody;

        public RigidbodyHolder(Rigidbody rigidbody) => _rigidbody = rigidbody;

        public Vector3 Velocity { get => _rigidbody.velocity; set => _rigidbody.velocity = value; }
        public bool IsKinematic { get => _rigidbody.isKinematic; set => _rigidbody.isKinematic = value; }
    }
}
