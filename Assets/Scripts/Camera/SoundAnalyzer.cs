using System;
using UnityEngine;

namespace GachiBird.Camera
{
    public class SoundAnalyzer : MonoBehaviour
    {
        private readonly float[] _spectrumData = new float[512];
        
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private FFTWindow _fftWindow;
        
        public float GetValue(FrequencyRange frequencyRange, float minValue, float maxValue)
        {
            _audioSource.GetSpectrumData(_spectrumData, 0, _fftWindow);

            float value = 0;

            for (int i = frequencyRange.Start; i <= frequencyRange.End; i++)
            {
                value += _spectrumData[i];
            }

            if (value < minValue)
            {
                return 0;
            }

            return Math.Min(value, maxValue);
        }
    }
}
