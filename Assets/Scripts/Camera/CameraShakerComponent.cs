using System;
using AreYouFruits.Common;
using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Audio;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GachiBird.Camera
{
    public class CameraShakerComponent : AbstractComponent<ICameraEffect>
    {
        [Header("References")]
        [SerializeField] private SoundAnalyzerComponent _soundAnalyzer;

        [Header("Settings")]
        [SerializeField] private ShakeType _shakeType;
        [SerializeField] private float _powerThreshold;
        [SerializeField] private float _maxPower;
        [SerializeField] private Range<int> _frequencyRange;

        protected override ICameraEffect Create() => new CameraShaker(
            _soundAnalyzer.HeldItem,
            _shakeType,
            _powerThreshold,
            _maxPower,
            _frequencyRange
        );
    }

    public class CameraShaker : ICameraEffect
    {
        private readonly SoundAnalyzer _soundAnalyzer;

        private readonly ShakeType _shakeType;
        private readonly float _powerThreshold;
        private readonly float _maxPower;
        private readonly Range<int> _frequencyRange;

        public CameraShaker(
            SoundAnalyzer soundAnalyzer, ShakeType shakeType, float powerThreshold, float maxPower,
            Range<int> frequencyRange
        )
        {
            _soundAnalyzer = soundAnalyzer;
            _shakeType = shakeType;
            _powerThreshold = powerThreshold;
            _maxPower = maxPower;
            _frequencyRange = frequencyRange;
        }

        private Vector3 GetRandomPower(float maxValue)
        {
            return Random.insideUnitCircle * maxValue;
        }

        private Vector3 GetSoundDependentPower(float maxValue)
        {
            float power = _soundAnalyzer.GetValue(_frequencyRange, _powerThreshold, maxValue);

            return GetRandomPower(power);
        }

        public void Apply(UnityEngine.Camera camera)
        {
            camera.transform.position += _shakeType switch
            {
                ShakeType.Random => GetRandomPower(_maxPower),
                ShakeType.SoundDependent => GetSoundDependentPower(_maxPower),
                _ => throw new ArgumentOutOfRangeException(),
            };
        }
    }
}
