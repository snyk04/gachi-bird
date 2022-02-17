using System;
using AreYouFruits.Common;
using UnityEngine;

namespace GachiBird.Audio
{
    public sealed class SoundAnalyzer : ISoundAnalyzer
    {
        private const int LeftChannelIndex = 0;
        private const int RightChannelIndex = 1;

        private readonly AudioSource _audioSource;
        private readonly FFTWindow _fftWindow;
        private readonly float[] _spectrumData;
        private readonly float[] _normalizedSpectrumData;
        public Range<int> PossibleRange { get; }

        public int SpectrumLength { get; }

        public SoundAnalyzer(AudioSource audioSource, SpectrumDataSize spectrumDataSize, FFTWindow fftWindow)
        {
            _audioSource = audioSource;
            _fftWindow = fftWindow;
            SpectrumLength = spectrumDataSize.GetPower();
            _spectrumData = new float[(int)spectrumDataSize];
            _normalizedSpectrumData = new float[SpectrumLength];
            PossibleRange = new Range<int>(0, SpectrumLength - 1);
        }

        public float GetAmplitude(Range<int> frequencyRange, float threshold, float maxValue)
        {
            if (!PossibleRange.Contains(frequencyRange))
            {
                throw new ArgumentOutOfRangeException();
            }
            
            float[] spectrum = GetSpectrum();
            
            float value = 0;

            for (int i = frequencyRange.Min; i <= frequencyRange.Max; i++)
            {
                value += spectrum[i];
            }

            if (value < threshold)
            {
                return 0;
            }

            return Mathf.Min(value, maxValue);
        }
        
        public static void NormalizeSpectrum(float[] spectrum, float[] normalized)
        {
            if ((1 << normalized.Length) != spectrum.Length)
            {
                throw new ArgumentException();
            }

            int count = 0;
            int power = 0;

            for (; (1 << power) < spectrum.Length; power++)
            {
                float sum = 0;

                for (; count < ((1 << (power + 1)) - 1); count++)
                {
                    sum += spectrum[count];
                }

                normalized[power] = sum / (power + 1);
            }

            for (int i = 0; i < normalized.Length; i++)
            {
                normalized[i] *= power * 0.5f;
            }
        }

        public float[] GetSpectrum()
        {
            _audioSource.GetSpectrumData(_spectrumData, LeftChannelIndex, _fftWindow);
            NormalizeSpectrum(_spectrumData, _normalizedSpectrumData);

            return _normalizedSpectrumData;
        }
    }
}
