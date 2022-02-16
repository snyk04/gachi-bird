using System;
using GachiBird.Game;
using UnityEngine;

namespace GachiBird.PlayerLogic
{
    public sealed class Player : IPlayer
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly float _jumpForce;

        public event Action? OnJump;

        public Player(IGameCycle gameCycle, Rigidbody2D rigidbody, float jumpForce, float speed)
        {
            _rigidbody = rigidbody;
            _jumpForce = jumpForce;

            gameCycle.OnGameStart += HandleGameStart;
            gameCycle.OnGameEnd += HandleGameEnd;
            
            _rigidbody.velocity = speed * Vector2.right;
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

        public void Jump()
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
            OnJump?.Invoke();
        }
    }
}
