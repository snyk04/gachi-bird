#nullable enable

using System;
using System.Threading;
using System.Threading.Tasks;
using AreYouFruits.Common;
using AreYouFruits.Common.ComponentGeneration;
using UnityEngine;

namespace GachiBird.PlayerLogic
{
    public class PlayerBordersTriggerComponent : DestroyableAbstractComponent<PlayerBordersTrigger>
    {
#nullable disable
        [SerializeField] private Transform _player;
        [SerializeField] private Range<float> _heightBounds;
#nullable enable
        
        protected override PlayerBordersTrigger Create()
        {
            var trigger = new PlayerBordersTrigger(_player, _heightBounds);
            trigger.Start();
            
            return trigger;
        }

        private void OnDrawGizmosSelected()
        {
            if (_heightBounds.IsBounded)
            {
                Gizmos.color = Color.cyan;
                Vector3 center = (_heightBounds.Min + _heightBounds.Max) / 2.0f * Vector3.up;
                const float depth = 10.0f;
                const float width = 100_000.0f;
                Gizmos.DrawWireCube(center, new Vector3(width, _heightBounds.Max - _heightBounds.Min, depth));
            }
        }
    }

    public class PlayerBordersTrigger : IDisposable
    {
        private readonly Transform _player;
        private readonly Range<float> _heightBounds;
        private readonly CancellationTokenSource _cancellationSource = new CancellationTokenSource();

        private float _lastPlayerY;

        public event Action OnPlayerOutOfBounds;
        
        public PlayerBordersTrigger(Transform player, Range<float> heightBounds)
        {
            _player = player;
            _heightBounds = heightBounds;
        }

        public async void Start()
        {
            while (!_cancellationSource.IsCancellationRequested)
            {
                if (!_heightBounds.Contains(_player.position.y) && _heightBounds.Contains(_lastPlayerY))
                {
                    OnPlayerOutOfBounds?.Invoke();
                }

                _lastPlayerY = _player.position.y;
                
                await Task.Yield();
            }
        }
        
        public void Dispose() => _cancellationSource.Cancel();
    }
}
