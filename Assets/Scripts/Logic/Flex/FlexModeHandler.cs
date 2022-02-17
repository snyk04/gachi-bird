#nullable enable

using System;
using System.Threading;
using AreYouFruits.Common;
using GachiBird.Environment.Objects;
using GachiBird.Game;
using UnityEngine;

namespace GachiBird.Flex
{
    public sealed class FlexModeHandler : IFlexModeHandler, IDisposable
    {
        public event Action<BoosterInfo>? OnFlexModeStart;
        public event Action? OnFlexModeEnd;

        private bool _isInFlexMode;
        
        private readonly CancellationTokenSource _cancellationSource = new CancellationTokenSource();

        public FlexModeHandler(IGameCycle gameCycle)
        {
            gameCycle.OnGameEnd += StopFlexMode;
            gameCycle.OnGameEnd += Dispose;
        }
        
        public async void StartFlexMode(GameObject boosterObject, IBooster booster, BoosterInfo boosterInfo)
        {
            if (_isInFlexMode)
            {
                return;
            }
            _isInFlexMode = true;
            
            OnFlexModeStart?.Invoke(boosterInfo);
            booster.PickedUp -= StartFlexMode;
            
            await Tasks.DelaySeconds(boosterInfo.Music.length);

            if (!_cancellationSource.IsCancellationRequested)
            {
                StopFlexMode();
            }
        }
        private void StopFlexMode()
        {
            if (_isInFlexMode)
            {
                OnFlexModeEnd?.Invoke();
                _isInFlexMode = false;
            }
        }

        public void Dispose()
        {
            _cancellationSource.Cancel();
        }
    }
}