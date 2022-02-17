using AreYouFruits.Common;
using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Audio;
using UnityEngine;

namespace GachiBird.Flex
{
    public sealed class VisualFlexerComponent : AbstractComponent<VisualFlexer>
    {
#nullable disable
        [SerializeField] private Material _material;
        [SerializeField] private SerializedInterface<IComponent<IFlexModeHandler>> _flexModeHandler;
        [SerializeField] private SerializedInterface<IComponent<ISoundAnalyzer>> _soundAnalyzer;
        [SerializeField] private float _threshold;
        [SerializeField] private float _maxValue;
#nullable enable

        protected override VisualFlexer Create() => new VisualFlexer(
            _material,
            _flexModeHandler.GetHeldItem(),
            _soundAnalyzer.GetHeldItem(),
            _threshold,
            _maxValue
        );
    }
}
