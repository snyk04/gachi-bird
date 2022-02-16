#nullable enable

using System.Threading;
using System.Threading.Tasks;
using AreYouFruits.Common;
using GachiBird.Environment;
using GachiBird.Environment.Objects;
using UnityEngine;

namespace GachiBird.Game.FlexMode
{
    public class FlexModeHandler : IFlexModeHandler
    {
        private readonly AudioSource _backgroundMusicAudioSource;
        private readonly AudioSource _flexMusicAudioSource;
        
        private readonly CancellationTokenSource _cancellationSource = new CancellationTokenSource();

        public FlexModeHandler(IBoosterSpawner boosterSpawner, 
            AudioSource backgroundMusicAudioSource, AudioSource flexMusicAudioSource)
        {
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