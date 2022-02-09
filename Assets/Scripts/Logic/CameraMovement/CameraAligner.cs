#nullable enable

using System.Threading.Tasks;
using GachiBird.Game;
using UnityEngine;

namespace GachiBird.CameraMovement
{
    public sealed class CameraAligner : ICameraEffect
    {
        private readonly Transform _objectToAlign;

        private Vector2 _cameraOffset;
        private float _smoothTime;

        private Vector3 _alignmentVelocity;

        public CameraAligner(
            IGameCycle gameCycle, Transform objectToAlign,
            Vector2 defaultCameraOffset, float defaultSmoothTime, float timeToMoveCameraToGamePosition
        )
        {
            _objectToAlign = objectToAlign;

            _cameraOffset = Vector2.zero;
            _smoothTime = 0;
            
            void SetSmoothTimeToDefaultValue() => _smoothTime = defaultSmoothTime;

            gameCycle.OnGameStart += SetSmoothTimeToDefaultValue;
            gameCycle.OnGameStart += () => _cameraOffset = defaultCameraOffset;
            gameCycle.OnGameStart += () => ChangeSmoothTimeToZero(timeToMoveCameraToGamePosition);

            gameCycle.OnGameEnd += SetSmoothTimeToDefaultValue;
        }

        private async void ChangeSmoothTimeToZero(float timeToChange)
        {
            int counter = 0;

            while (counter < 10)
            {
                _smoothTime = Mathf.Lerp(_smoothTime, 0, counter / 10f);
                counter += 1;

                await Task.Delay((int)(timeToChange * 1000));
            }
        }

        public void Apply(Camera camera)
        {
            Transform transform = camera.transform;
            Vector3 position = transform.position;
            
            var targetPosition = new Vector3(
                _objectToAlign.position.x + _cameraOffset.x,
                _cameraOffset.y,
                position.z
            );

            transform.position = Vector3.SmoothDamp(
                position,
                targetPosition,
                ref _alignmentVelocity,
                _smoothTime
            );
        }
    }
}
