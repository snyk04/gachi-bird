using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GachiBird.Camera
{
    public class CameraShaker : MonoBehaviour
    {
        [Header("References")] 
        [SerializeField] private SoundAnalyzer _soundAnalyzer;
        
        [Header("Settings")]
        [SerializeField] private ShakeType _shakeType;
        [SerializeField] private float _powerThreshold;
        [SerializeField] private float _maxPower;
        [SerializeField] private FrequencyRange _frequencyRange; 

        public Vector3 Power 
        {
            get
            {
                return _shakeType switch
                {
                    ShakeType.Random => RandomPower(_maxPower),
                    ShakeType.SoundDependent => SoundDependentPower(),
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
        }

        private Vector3 RandomPower(float maxValue)
        {
            return Random.insideUnitCircle * maxValue;
        }
        private Vector3 SoundDependentPower()
        {
            float power = _soundAnalyzer.GetValue(_frequencyRange, _powerThreshold, _maxPower);
            return RandomPower(power);
        }
    }
}
