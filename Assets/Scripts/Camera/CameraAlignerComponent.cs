using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Game;
using UnityEngine;

namespace GachiBird.Camera
{
    public sealed class CameraAlignerComponent : AbstractComponent<ICameraEffect>
    {
        [Header("References")]
        [SerializeField] private GameCycle _gameCycle;

        [Header("Settings")]
        [SerializeField] private Transform _objectToAlign;
        [SerializeField] private Vector2 _defaultCameraOffset;
        [SerializeField] private float _defaultSmoothTime;
        [SerializeField] private float _timeToMoveCameraToGamePosition;

        protected override ICameraEffect Create()
        {
            return new CameraAligner(
                _gameCycle,
                _objectToAlign,
                _defaultCameraOffset,
                _defaultSmoothTime,
                _timeToMoveCameraToGamePosition
            );
        }
    }

    public sealed class CameraAligner : ICameraEffect
    {
        private readonly Transform _objectToAlign;

        private Vector2 _currentCameraOffset;
        private float _currentSmoothTime;

        private Vector3 _alignmentVelocity;

        public CameraAligner(
            GameCycle gameCycle, Transform objectToAlign,
            Vector2 defaultCameraOffset, float defaultSmoothTime, float timeToMoveCameraToGamePosition
        )
        {
            _objectToAlign = objectToAlign;

            _currentCameraOffset = Vector2.zero;
            _currentSmoothTime = 0;
            
            void SetSmoothTimeToDefaultValue() => _currentSmoothTime = defaultSmoothTime;

            gameCycle.OnGameStart += SetSmoothTimeToDefaultValue;
            gameCycle.OnGameStart += () => _currentCameraOffset = defaultCameraOffset;
            gameCycle.OnGameStart += () => ChangeSmoothTimeToZero(timeToMoveCameraToGamePosition);

            gameCycle.OnGameEnd += SetSmoothTimeToDefaultValue;
        }

        private async void ChangeSmoothTimeToZero(float timeToChange)
        {
            int counter = 0;

            while (counter < 10)
            {
                _currentSmoothTime = Mathf.Lerp(_currentSmoothTime, 0, counter / 10f);
                counter += 1;

                await Task.Delay((int)(timeToChange * 1000));
            }
        }

        public void Apply(UnityEngine.Camera camera)
        {
            Transform transform = camera.transform;
            
            Vector3 targetPosition = new Vector3(
                _objectToAlign.position.x + _currentCameraOffset.x,
                _currentCameraOffset.y,
                transform.position.z
            );

            transform.position = Vector3.SmoothDamp(
                transform.position,
                targetPosition,
                ref _alignmentVelocity,
                _currentSmoothTime
            );
        }
    }

    public interface ICameraEffect
    {
        public void Apply(UnityEngine.Camera camera);
    }
}
