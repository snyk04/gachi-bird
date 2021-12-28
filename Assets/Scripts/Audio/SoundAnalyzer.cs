using System;
using UnityEngine;

namespace GachiBird.Audio
{
    public class SoundAnalyzer : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private SpectrumDataSize _spectrumDataSize;
        [SerializeField] private FFTWindow _fftWindow;

        private int _size;
        private float[] _spectrumData;

        private void Awake()
        {
            _size = (int) _spectrumDataSize;
            
            _spectrumData = new float[_size];
        }

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
