#nullable enable

using AreYouFruits.Common;
using UnityEngine;

namespace GachiBird.Audio
{
    public sealed class SoundAnalyzer : ISoundAnalyzer
    {
        private readonly AudioSource _audioSource;
        private readonly FFTWindow _fftWindow;
        private readonly float[] _spectrumData;

        public SoundAnalyzer(AudioSource audioSource, SpectrumDataSize spectrumDataSize, FFTWindow fftWindow)
        {
            _audioSource = audioSource;
            _fftWindow = fftWindow;
            _spectrumData = new float[(int)spectrumDataSize];
        }

        public float GetAmplitude(Range<int> frequencyRange, float minValue, float maxValue)
        {
            _audioSource.GetSpectrumData(_spectrumData, 0, _fftWindow);

            float value = 0;

            for (int i = frequencyRange.Min; i <= frequencyRange.Max; i++)
            {
                value += _spectrumData[i];
            }

            if (value < minValue)
            {
                return 0;
            }

            return Mathf.Min(value, maxValue);
        }
    }
}
