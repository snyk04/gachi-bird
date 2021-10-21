using System.Collections;
using UnityEngine;

namespace Camera
{
    public sealed class CameraAligner : MonoBehaviour
    {
        #region References

        [Header("References")]
        [SerializeField] private GameCycle _gameCycle;

        #endregion
        
        #region Components

        private Transform _transform;

        #endregion

        #region Settings

        [Header("Settings")]
        [SerializeField] private Transform _objectToAlign;
        [SerializeField] private Vector2 _defaultCameraOffset;
        [SerializeField] private float _defaultSmoothTime;
        [SerializeField] private float _timeToMoveCameraToGamePosition;

        #endregion

        #region Properties

        private Vector2 _currentCameraOffset;
        private float _currentSmoothTime;
        
        private Vector3 _alignmentVelocity;

        #endregion

        #region MonoBehaviour methods

        private void Awake()
        {
            _transform = transform;
            
            _currentCameraOffset = Vector2.zero;
            _currentSmoothTime = 0;

            _gameCycle.OnGameStart += SetSmoothTimeToDefaultValue;
            _gameCycle.OnGameStart += SetCameraOffsetToDefaultValue;
            _gameCycle.OnGameStart += () => StartCoroutine(ChangeSmoothTimeToZero(_timeToMoveCameraToGamePosition));
            
            _gameCycle.OnGameEnd += SetSmoothTimeToDefaultValue;

        }
        private void FixedUpdate()
        {
            AlignToObject(_objectToAlign);
        }

        #endregion

        #region Methods

        private void AlignToObject(Transform objectToAlign)
        {
            Vector3 targetPosition = new Vector3(
                objectToAlign.position.x + _currentCameraOffset.x,
                _currentCameraOffset.y,
                _transform.position.z
                );
            
            _transform.position = Vector3.SmoothDamp(
                transform.position, 
                targetPosition,
                ref _alignmentVelocity, 
                _currentSmoothTime
                );
        }
        
        private void SetCameraOffsetToDefaultValue()
        {
            _currentCameraOffset = _defaultCameraOffset;
        }
        private void SetSmoothTimeToDefaultValue()
        {
            _currentSmoothTime = _defaultSmoothTime;
        }

        private IEnumerator ChangeSmoothTimeToZero(float timeToChange)
        {
            int counter = 0;
            while (counter < 10)
            {
                _currentSmoothTime = Mathf.Lerp(_currentSmoothTime, 0, counter / 10f);
                counter += 1;
                yield return new WaitForSeconds(timeToChange / 10);
            }
        }

        #endregion
    }
}
