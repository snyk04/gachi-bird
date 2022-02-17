using System;
using AreYouFruits.Common;
using GachiBird.Audio;
using GachiBird.Environment.Objects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GachiBird.CameraMovement
{
    public sealed class CameraShaker : IFlexDependentCameraEffect
    {
        private readonly ISoundAnalyzer _soundAnalyzer;

        private readonly ShakeType _shakeType;
        private readonly float _powerThreshold;
        private readonly float _maxPower;
        private Range<int> _frequencyRange;

        private bool _isEnabled;
        
        public event Action? OnEnable;
        public event Action? OnDisable;

        public CameraShaker(
            ISoundAnalyzer soundAnalyzer, ShakeType shakeType, float powerThreshold, float maxPower)
        {
            _soundAnalyzer = soundAnalyzer;
            _shakeType = shakeType;
            _powerThreshold = powerThreshold;
            _maxPower = maxPower;
        }
        
        public void Enable(BoosterInfo boosterInfo)
        {
            _frequencyRange = boosterInfo.MusicFrequencyRange;
            _isEnabled = true;
            OnEnable?.Invoke();
        }
        public void Disable()
        {
            _isEnabled = false;
            OnDisable?.Invoke();
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
            if (!_isEnabled)
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