using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Game;
using UnityEngine;

namespace GachiBird.CameraMovement
{
    public sealed class CameraAlignerComponent : AbstractComponent<CameraAligner>
    {
#nullable disable
        [Header("References")]
        [SerializeField] private SerializedInterface<IComponent<IGameCycle>> _gameCycle;

        [Header("Settings")]
        [SerializeField] private Transform _objectToAlign;
        [SerializeField] private Vector2 _defaultCameraOffset;
        [SerializeField] private float _defaultSmoothTime;
        [SerializeField] private float _timeToMoveCameraToGamePosition;
#nullable enable
        
        protected override CameraAligner Create()
        {
            return new CameraAligner(
                _gameCycle.GetHeldItem(),
                _objectToAlign,
                _defaultCameraOffset,
                _defaultSmoothTime,
                _timeToMoveCameraToGamePosition
            );
        }
    }
}
