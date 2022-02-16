#nullable enable

using System;
using GachiBird.Game;
using UnityEngine;

namespace GachiBird.PlayerLogic
{
    public sealed class Player : IPlayer
    {
        public float Speed
        {
            set => _rigidbody.velocity = new Vector2(value, _rigidbody.velocity.y);
        }
        public event Action? OnJump;
        
        private readonly Rigidbody2D _rigidbody;
        private readonly float _jumpForce;
        private readonly float _defaultSpeed;
        
        public Player(IGameCycle gameCycle, Rigidbody2D rigidbody, float jumpForce, float speed)
        {
            _rigidbody = rigidbody;
            _jumpForce = jumpForce;
            _defaultSpeed = speed;

            gameCycle.OnGameStart += HandleGameStart;
            gameCycle.OnGameEnd += HandleGameEnd;

            _rigidbody.velocity = Vector2.right * _defaultSpeed;
        }

        public void Jump()
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
            OnJump?.Invoke();
        }
        public void ResetSpeed()
        {
            _rigidbody.velocity = new Vector2(_defaultSpeed, _rigidbody.velocity.y);
        }
        
        private void HandleGameStart()
        {
            _rigidbody.isKinematic = false;
        }
        private void HandleGameEnd()
        {
            _rigidbody.isKinematic = true;
            _rigidbody.velocity = Vector2.zero;
        }
    }
}
