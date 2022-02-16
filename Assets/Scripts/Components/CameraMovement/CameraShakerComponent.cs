using AreYouFruits.Common;
using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Audio;
using UnityEngine;

namespace GachiBird.CameraMovement
{
    public sealed class CameraShakerComponent : AbstractComponent<IControllableCameraEffect>
    {
#nullable disable
        [Header("References")]
        [SerializeField] private AbstractComponent<ISoundAnalyzer> _soundAnalyzer;

        [Header("Settings")]
        [SerializeField] private ShakeType _shakeType;
        [SerializeField] private float _powerThreshold;
        [SerializeField] private float _maxPower;
        [SerializeField] private Range<int> _frequencyRange;
#nullable enable
        
        protected override IControllableCameraEffect Create() => new CameraShaker(
            _soundAnalyzer.HeldItem,
            _shakeType,
            _powerThreshold,
            _maxPower,
            _frequencyRange
        );
    }
}
