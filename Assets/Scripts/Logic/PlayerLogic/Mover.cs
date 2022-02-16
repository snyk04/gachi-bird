using AreYouFruits.Common;
using UnityEngine;

namespace GachiBird.PlayerLogic
{
    public sealed class Mover : IMovable
    {
        public float Speed
        {
            set => _rigidbody.velocity = _rigidbody.velocity.DroppedX(value);
        }

        private readonly Rigidbody2D _rigidbody;
        private readonly float _defaultSpeed;

        public Mover(Rigidbody2D rigidbody, float speed)
        {
            _rigidbody = rigidbody;
            _defaultSpeed = speed;
            
            _rigidbody.velocity = speed * Vector2.right;
        }

        public void ResetSpeed()
        {
            _rigidbody.velocity = _rigidbody.velocity.DroppedX(_defaultSpeed);
        }
    }
}