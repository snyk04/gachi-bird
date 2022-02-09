#nullable enable

using AreYouFruits.Common.ComponentGeneration;
using UnityEngine;

namespace GachiBird.Audio
{
    public sealed class AudioVisualizerComponent : DestroyableAbstractComponent<AudioVisualizer>
    {
#nullable disable
        [SerializeField] private AudioSource _audioSource;

        [Header("Analyzing")] 
        [SerializeField] private SpectrumDataSize _spectrumDataSize;
        [SerializeField] private FFTWindow _fftWindow;

        [Header("Visualizing")]
        [SerializeField] private GameObject _partPrefab;
        [SerializeField] private GameObject _partContainer;
#nullable enable

        protected override AudioVisualizer Create()
        {
            var item = new AudioVisualizer(
                _audioSource,
                _spectrumDataSize,
                _fftWindow,
                _partPrefab,
                _partContainer
            );

            item.Start();

            return item;
        }
    }
}
