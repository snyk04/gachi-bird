#nullable enable

using System.Threading;
using AreYouFruits.Common;
using GachiBird.CameraMovement;
using GachiBird.Environment;
using GachiBird.Environment.Objects;
using GachiBird.PlayerLogic;
using UnityEngine;

namespace GachiBird.Game.FlexMode
{
    public sealed class FlexModeHandler : IFlexModeHandler
    {
        private readonly IPlayer _player;
        private readonly IControllableCameraEffect[] _cameraEffects;
        private readonly AudioSource _backgroundMusicAudioSource;
        private readonly AudioSource _flexMusicAudioSource;
        
        private readonly CancellationTokenSource _cancellationSource = new CancellationTokenSource();

        public FlexModeHandler(IPlayer player, IControllableCameraEffect[] cameraEffects,
            IBoosterSpawner boosterSpawner, IGameCycle gameCycle, AudioSource backgroundMusicAudioSource,
            AudioSource flexMusicAudioSource)
        {
            _player = player;
            _cameraEffects = cameraEffects;
            _backgroundMusicAudioSource = backgroundMusicAudioSource;
            _flexMusicAudioSource = flexMusicAudioSource;

            boosterSpawner.OnBoosterSpawned += HandleBoosterSpawned;
            gameCycle.OnGameEnd += () => StopFlexMode(true);
        }
        
        private async void StartFlexMode(GameObject boosterObject, IBooster booster, BoosterInfo boosterInfo)
        {
            booster.PickedUp -= StartFlexMode;
            
            _backgroundMusicAudioSource.Pause();
            _flexMusicAudioSource.clip = boosterInfo.Music;
            _flexMusicAudioSource.Play();

            _player.Speed = boosterInfo.PlayerSpeed;
            foreach (IControllableCameraEffect cameraEffect in _cameraEffects)
            {
                cameraEffect.IsEnabled = true;
            }
            
            await Tasks.DelaySeconds(boosterInfo.Music.length);

            if (!_cancellationSource.IsCancellationRequested)
            {
                StopFlexMode(false);
            }
        }
        private void StopFlexMode(bool isGameStopped)
        {
            _flexMusicAudioSource.Stop();
            _backgroundMusicAudioSource.UnPause();
            
            foreach (IControllableCameraEffect cameraEffect in _cameraEffects)
            {
                cameraEffect.IsEnabled = false;
            }

            if (!isGameStopped)
            {
                _player.ResetSpeed();
            }
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