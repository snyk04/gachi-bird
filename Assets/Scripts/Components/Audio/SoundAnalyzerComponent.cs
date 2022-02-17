using AreYouFruits.Common.ComponentGeneration;
using UnityEngine;

namespace GachiBird.Audio
{
    public class SoundAnalyzerComponent : AbstractComponent<SoundAnalyzer, ISoundAnalyzer>
    {
#nullable disable
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private SpectrumDataSize _spectrumDataSize;
        [SerializeField] private FFTWindow _fftWindow;
#nullable enable

        protected override SoundAnalyzer Create()
        {
            return new SoundAnalyzer(_audioSource, _spectrumDataSize, _fftWindow);
        }
    }
}
