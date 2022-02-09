﻿#nullable enable

using System;
using System.Threading;
using System.Threading.Tasks;
using AreYouFruits.Common;
using UnityEngine;

namespace GachiBird.PlayerLogic
{
    public sealed class PlayerBordersTrigger : IPlayerBordersTrigger, IDisposable
    {
        private readonly Transform _player;
        private readonly Range<float> _heightBounds;
        private readonly CancellationTokenSource _cancellationSource = new CancellationTokenSource();

        private float _lastPlayerY;

        public event Action? OnPlayerOutOfBounds;
        
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