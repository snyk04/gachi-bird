#nullable enable

using AreYouFruits.Common;
using AreYouFruits.Common.ComponentGeneration;
using UnityEngine;

namespace GachiBird.Audio
{
    public class SoundAnalyzerComponent : AbstractComponent<ISoundAnalyzer>
    {
#nullable disable
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private SpectrumDataSize _spectrumDataSize;
        [SerializeField] private FFTWindow _fftWindow;
#nullable enable

        protected override ISoundAnalyzer Create()
        {
            return new SoundAnalyzer(_audioSource, _spectrumDataSize, _fftWindow);
        }
    }

    public interface ISoundAnalyzer
    {
        float GetAmplitude(Range<int> frequencyRange, float minValue, float maxValue);
    }

    public class SoundAnalyzer : ISoundAnalyzer
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
