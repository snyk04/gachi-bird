using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Game;
using UnityEngine;

namespace GachiBird.CameraMovement
{
    public sealed class CameraAlignerComponent : AbstractComponent<ICameraEffect>
    {
#nullable disable
        [Header("References")]
        [SerializeField] private AbstractComponent<IGameCycle> _gameCycle;

        [Header("Settings")]
        [SerializeField] private Transform _objectToAlign;
        [SerializeField] private Vector2 _defaultCameraOffset;
        [SerializeField] private float _defaultSmoothTime;
        [SerializeField] private float _timeToMoveCameraToGamePosition;
#nullable enable
        
        protected override ICameraEffect Create()
        {
            return new CameraAligner(
                _gameCycle.HeldItem,
                _objectToAlign,
                _defaultCameraOffset,
                _defaultSmoothTime,
                _timeToMoveCameraToGamePosition
            );
        }
    }
}
