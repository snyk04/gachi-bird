﻿#nullable enable

using System.Threading;
using AreYouFruits.Common;
using GachiBird.CameraMovement;
using GachiBird.Environment;
using GachiBird.Environment.Objects;
using GachiBird.FlexVisual;
using GachiBird.PlayerLogic;
using UnityEngine;

namespace GachiBird.Game.FlexMode
{
    public sealed class FlexModeHandler : IFlexModeHandler
    {
        private readonly Rigidbody2D _player;
        private readonly IControllableCameraEffect[] _cameraEffects;
        private readonly AudioSource _backgroundMusicAudioSource;
        private readonly AudioSource _flexMusicAudioSource;
        private readonly PostFXFeature _flexRenderFeature;
        
        private readonly CancellationTokenSource _cancellationSource = new CancellationTokenSource();
        
        private float _playerDefaultSpeed;

        public FlexModeHandler(Rigidbody2D player, IControllableCameraEffect[] cameraEffects,
            IBoosterSpawner boosterSpawner, IGameCycle gameCycle, AudioSource backgroundMusicAudioSource,
            AudioSource flexMusicAudioSource, PostFXFeature flexRenderFeature
        )
        {
            _player = player;
            _cameraEffects = cameraEffects;
            _backgroundMusicAudioSource = backgroundMusicAudioSource;
            _flexMusicAudioSource = flexMusicAudioSource;
            _flexRenderFeature = flexRenderFeature;

            boosterSpawner.OnBoosterSpawned += HandleBoosterSpawned;
            gameCycle.OnGameEnd += () => StopFlexMode(true);
        }
        
        private async void StartFlexMode(GameObject boosterObject, IBooster booster, BoosterInfo boosterInfo)
        {
            booster.PickedUp -= StartFlexMode;

            _flexRenderFeature.IsActive = true;
            
            _backgroundMusicAudioSource.Pause();
            _flexMusicAudioSource.clip = boosterInfo.Music;
            _flexMusicAudioSource.Play();

            _playerDefaultSpeed = _player.velocity.x;
            _player.velocity = _player.velocity.DroppedX(boosterInfo.PlayerSpeed);
            
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
            _flexRenderFeature.IsActive = false;
            
            _flexMusicAudioSource.Stop();
            _backgroundMusicAudioSource.UnPause();
            
            foreach (IControllableCameraEffect cameraEffect in _cameraEffects)
            {
                cameraEffect.IsEnabled = false;
            }

            if (!isGameStopped)
            {
                _player.velocity = _player.velocity.DroppedX(_playerDefaultSpeed);
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