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
        
        private readonly CancellationTokenSource _cancellationSource = new CancellationTokenSource();

        public FlexModeHandler(IGameCycle gameCycle)
        {
            gameCycle.OnGameEnd += StopFlexMode;
            gameCycle.OnGameEnd += Dispose;
        }
        
        public async void StartFlexMode(GameObject boosterObject, IBooster booster, BoosterInfo boosterInfo)
        {
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
            OnFlexModeEnd?.Invoke();
        }

        public void Dispose()
        {
            _cancellationSource.Cancel();
        }
    }
}