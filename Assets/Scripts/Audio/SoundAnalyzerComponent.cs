#nullable enable

using AreYouFruits.Common;
using AreYouFruits.Common.ComponentGeneration;
using UnityEngine;

namespace GachiBird.Audio
{
#nullable disable
    public class SoundAnalyzerComponent : AbstractComponent<SoundAnalyzer>
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private SpectrumDataSize _spectrumDataSize;
        [SerializeField] private FFTWindow _fftWindow;

        protected override SoundAnalyzer Create() => new SoundAnalyzer(_audioSource, _spectrumDataSize, _fftWindow);
    }
#nullable enable

    public class SoundAnalyzer
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

        public float GetValue(Range<int> frequencyRange, float minValue, float maxValue)
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
