using System;
using GachiBird.Game;
using UnityEngine;

namespace GachiBird.PlayerLogic
{
    public sealed class Jumper : IJumpable
    {
        private readonly Rigidbody2D _rigidbody;
        public float JumpForce { get; }

        public event Action? OnJump;

        public Jumper(IGameCycle gameCycle, Rigidbody2D rigidbody, float jumpForce)
        {
            _rigidbody = rigidbody;
            JumpForce = jumpForce;

            gameCycle.OnGameStart += HandleGameStart;
        }

        private void HandleGameStart()
        {
            _rigidbody.isKinematic = false;
        }

        public void Jump()
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, JumpForce);
            OnJump?.Invoke();
        }
    }
}
