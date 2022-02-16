#nullable enable

using System.Threading;
using System.Threading.Tasks;
using AreYouFruits.Common;
using GachiBird.Environment;
using GachiBird.Environment.Objects;
using GachiBird.PlayerLogic;
using UnityEngine;

namespace GachiBird.Game.FlexMode
{
    public sealed class FlexModeHandler : IFlexModeHandler
    {
        private readonly IPlayer _player;
        private readonly AudioSource _backgroundMusicAudioSource;
        private readonly AudioSource _flexMusicAudioSource;
        
        private readonly CancellationTokenSource _cancellationSource = new CancellationTokenSource();

        public FlexModeHandler(IBoosterSpawner boosterSpawner, IPlayer player,
            AudioSource backgroundMusicAudioSource, AudioSource flexMusicAudioSource)
        {
            _player = player;
            _backgroundMusicAudioSource = backgroundMusicAudioSource;
            _flexMusicAudioSource = flexMusicAudioSource;

            boosterSpawner.OnBoosterSpawned += HandleBoosterSpawned;
        }
        
        private async void StartFlexMode(GameObject boosterObject, IBooster booster, BoosterInfo boosterInfo)
        {
            booster.PickedUp -= StartFlexMode;
            
            _backgroundMusicAudioSource.Pause();
            _flexMusicAudioSource.clip = boosterInfo.Music;
            _flexMusicAudioSource.Play();

            _player.Speed = boosterInfo.PlayerSpeed;
            
            await Task.Delay(boosterInfo.Music.length.SecondsToMilliseconds());

            if (!_cancellationSource.IsCancellationRequested)
            {
                StopFlexMode();
            }
        }
        private void StopFlexMode()
        {
            _flexMusicAudioSource.Stop();
            _backgroundMusicAudioSource.UnPause();
            
            _player.ResetSpeed();
        }
        
        private void HandleBoosterSpawned(IBooster booster)
        {
            booster.PickedUp += StartFlexMode;
        }
        
        public void Dispose()
        {
            _cancellationSource.Cancel();
        }
    }
}