﻿using System;
using AreYouFruits.Common;
using GachiBird.Audio;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GachiBird.CameraMovement
{
    public sealed class CameraShaker : IControllableCameraEffect
    {
        private readonly ISoundAnalyzer _soundAnalyzer;

        private readonly ShakeType _shakeType;
        private readonly float _powerThreshold;
        private readonly float _maxPower;
        private readonly Range<int> _frequencyRange;

        private bool _isEnabled;
        public bool IsEnabled 
        {
            get => _isEnabled;
            set
            {
                _isEnabled = value;
                if (_isEnabled)
                {
                    OnEnable?.Invoke();
                }
                OnDisable?.Invoke();
            }
        }
        public event Action? OnEnable;
        public event Action? OnDisable;
        
        public CameraShaker(
            ISoundAnalyzer soundAnalyzer, ShakeType shakeType, float powerThreshold, float maxPower,
            Range<int> frequencyRange
        )
        {
            _soundAnalyzer = soundAnalyzer;
            _shakeType = shakeType;
            _powerThreshold = powerThreshold;
            _maxPower = maxPower;
            _frequencyRange = frequencyRange;

            _isEnabled = false;
        }

        private Vector3 GetRandomPower(float maxValue)
        {
            return Random.insideUnitCircle * maxValue;
        }

        private Vector3 GetSoundDependentPower(float maxValue)
        {
            float power = _soundAnalyzer.GetAmplitude(_frequencyRange, _powerThreshold, maxValue);

            return GetRandomPower(power);
        }

        public void Apply(Camera camera)
        {
            if (!IsEnabled)
            {
                return;
            }
            
            camera.transform.position += _shakeType switch
            {
                ShakeType.Random => GetRandomPower(_maxPower),
                ShakeType.SoundDependent => GetSoundDependentPower(_maxPower),
                _ => throw new ArgumentOutOfRangeException(),
            };
        }
    }
}
