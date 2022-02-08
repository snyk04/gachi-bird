#nullable enable

using System;
using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Game;
using UnityEngine;

namespace GachiBird.PlayerLogic
{
    public sealed class PlayerComponent : AbstractComponent<Player>
    {
#nullable disable
        [SerializeField] private GameCycleComponent _gameCycle;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _speed;
#nullable enable
        
        protected override Player Create() => new Player(_gameCycle.HeldItem, _rigidbody, _jumpForce, _speed);
    }

    public sealed class Player
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly float _jumpForce;
        private readonly float _speed;

        public event Action OnJump;

        public Player(GameCycle gameCycle, Rigidbody2D rigidbody, float jumpForce, float speed)
        {
            _rigidbody = rigidbody;
            _jumpForce = jumpForce;
            _speed = speed;

            gameCycle.OnGameStart += HandleGameStart;
            gameCycle.OnGameEnd += HandleGameEnd;
            
            _rigidbody.velocity = _speed * Vector2.right;
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
