using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Audio;
using UnityEngine;

namespace GachiBird.Flex
{
    public sealed class SoundVisualizerComponent : DestroyableAbstractComponent<SoundVisualizer>
    {
#nullable disable
        [SerializeField] private Material _audioMaterial;
        [SerializeField] private SerializedInterface<IComponent<ISoundAnalyzer>> _soundAnalyzer;
#nullable enable

        protected override SoundVisualizer Create()
        {
            var item = new SoundVisualizer(_audioMaterial, _soundAnalyzer.GetHeldItem());
            item.Start();

            return item;
        }
    }
}
