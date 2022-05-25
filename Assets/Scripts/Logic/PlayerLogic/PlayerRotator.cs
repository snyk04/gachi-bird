using UnityEngine;

namespace GachiBird.PlayerLogic
{
    public class PlayerRotator : IRotatable
    {
        private readonly IJumpable _jumpable;
        private readonly Rigidbody2D _rigidbody;
        private readonly Transform _transform;

        private readonly float _maxRotateAngle;

        public PlayerRotator(IJumpable jumpable, Rigidbody2D rigidbody, Transform transform, float maxRotateAngle)
        {
            _jumpable = jumpable;
            _rigidbody = rigidbody;
            _transform = transform;
            _maxRotateAngle = maxRotateAngle;
        }

        public void Rotate()
        {
            float playerForceY = Mathf.Clamp(_rigidbody.velocity.y / _jumpable.JumpForce, -1, 1);
            _transform.rotation = Quaternion.Euler(0, 0, playerForceY * _maxRotateAngle);
        }
    }
}