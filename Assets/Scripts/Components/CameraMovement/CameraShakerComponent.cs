using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Audio;
using UnityEngine;

namespace GachiBird.CameraMovement
{
    public sealed class CameraShakerComponent 
        : AbstractComponent<CameraShaker, IFlexDependentCameraEffect, ICameraEffect>
    {
#nullable disable
        [Header("References")]
        [SerializeField] private SerializedInterface<IComponent<ISoundAnalyzer>> _soundAnalyzer;

        [Header("Settings")]
        [SerializeField] private ShakeType _shakeType;
        [SerializeField] private float _powerThreshold;
        [SerializeField] private float _maxPower;
#nullable enable
        
        protected override CameraShaker Create() => new CameraShaker(
            _soundAnalyzer.GetHeldItem(),
            _shakeType,
            _powerThreshold,
            _maxPower
        );
    }
}