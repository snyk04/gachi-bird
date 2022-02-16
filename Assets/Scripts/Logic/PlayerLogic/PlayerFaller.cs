using System;
using System.Threading;
using System.Threading.Tasks;
using AreYouFruits.Common;
using GachiBird.Game;
using UnityEngine;

namespace GachiBird.PlayerLogic
{
    public sealed class PlayerFaller : IDisposable
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly Collider2D _collider;
        private readonly Transform _transform;
        private readonly float _minPosition;

        private readonly CancellationTokenSource _cancellationSource = new CancellationTokenSource();

        public event Action? OnFall;

        public PlayerFaller(
            IGameCycle gameCycle, Rigidbody2D rigidbody, Collider2D collider, Transform transform,
            IPlayerBordersTrigger playerBorders
        )
        {
            _rigidbody = rigidbody;
            _transform = transform;
            _collider = collider;
            _minPosition = playerBorders.HeightBounds.Min;

            gameCycle.OnGameEnd += () => Fall(_cancellationSource.Token);
        }

        private async void Fall(CancellationToken cancellation)
        {
            _rigidbody.velocity = Vector2.zero;
            _collider.isTrigger = true;

            while (!cancellation.IsCancellationRequested && _transform.position.y > _minPosition)
            {
                await Task.Yield();
            }

            if (cancellation.IsCancellationRequested)
            {
                return;
            }

            _transform.position = _transform.position.DroppedY(_minPosition);
            _rigidbody.isKinematic = true;
            _rigidbody.velocity = Vector2.zero;
            
            OnFall?.Invoke();
        }

        public void Dispose() => _cancellationSource.Cancel();
    }
}
