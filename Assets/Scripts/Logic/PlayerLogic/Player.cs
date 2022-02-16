using System;
using AreYouFruits.Common.ComponentGeneration;
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

            _rigidbody.velocity = speed * Vector2.right;
        }

        private void HandleGameStart()
        {
            _rigidbody.isKinematic = false;
        }

        public void Jump()
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
            OnJump?.Invoke();
        }
    }
}
